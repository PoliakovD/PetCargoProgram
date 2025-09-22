using System;

namespace PetCargoProgram.DataAccess;

public class SaveToJsonException(string path, Exception innerException)
    : Exception($"Ошибка сохранения JSON в {path}", innerException);

public class LoadFromJsonException : Exception
{
    public LoadFromJsonException(string path, Exception? innerException = null)
        : base($"Ошибка загрузки JSON из {path}", innerException) { }
}
