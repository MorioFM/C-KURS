using System.Data;
using System.Data.Common;

namespace MyAPP.Common;

/// <summary>
/// Потокобезопасная generic-обёртка над подключением к базе данных (DbConnection).
/// Реализует паттерн «одно постоянное соединение»:
/// - Держит ровно одно постоянное соединение на протяжении всего жизненного цикла.
/// - Выстраивает параллельные обращения в очередь с помощью lock (_lock).
/// - Автоматически проверяет и открывает соединение (EnsureOpen) перед выполнением команды.
/// - Принимает инструкции в виде функций высшего порядка (делегатов Func/Action).
/// - Аккуратно закрывает соединение только при вызове Dispose().
/// </summary>
/// <typeparam name="TConnection">Тип подключения, унаследованный от DbConnection (SqliteConnection, MySqlConnection и т.д.)</typeparam>
public class DbConnectionWrapper<TConnection> : IDisposable where TConnection : DbConnection
{
    private readonly TConnection _connection;
    private readonly object _lock = new();
    private bool _disposed;

    /// <summary>
    /// Инициализирует обёртку переданным экземпляром подключения
    /// </summary>
    /// <param name="connection">Экземпляр подключения к СУБД</param>
    public DbConnectionWrapper(TConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    /// <summary>
    /// Проверяет состояние соединения и открывает его, если оно закрыто
    /// </summary>
    private void EnsureOpen()
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }
    }

    /// <summary>
    /// Функция высшего порядка для выполнения операций с возвратом результата (TResult).
    /// Автоматически синхронизирует доступ через lock, гарантирует открытое состояние соединения
    /// и возвращает результат выполнения переданного делегата.
    /// </summary>
    /// <typeparam name="TResult">Тип возвращаемого значения (int, bool, List&lt;T&gt; и т.д.)</typeparam>
    /// <param name="action">Инструкция (делегат), принимающая открытое подключение</param>
    /// <returns>Результат выполнения переданной инструкции</returns>
    public TResult Execute<TResult>(Func<TConnection, TResult> action)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(action);

        lock (_lock)
        {
            EnsureOpen();
            return action(_connection);
        }
    }

    /// <summary>
    /// Функция высшего порядка для выполнения операций без возврата результата (void).
    /// Автоматически синхронизирует доступ через lock и гарантирует открытое состояние соединения.
    /// </summary>
    /// <param name="action">Инструкция (делегат), принимающая открытое подключение</param>
    public void Execute(Action<TConnection> action)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(action);

        lock (_lock)
        {
            EnsureOpen();
            action(_connection);
        }
    }

    /// <summary>
    /// Закрывает и освобождает соединение ровно один раз в конце жизненного цикла
    /// </summary>
    public void Dispose()
    {
        lock (_lock)
        {
            if (_disposed) return;
            _disposed = true;
            _connection.Dispose();
        }

        GC.SuppressFinalize(this);
    }
}

