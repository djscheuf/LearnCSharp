using DJS.Common.Enums;
using DJS.Common.Interfaces;
using System;
using System.IO;

namespace DJS.Common.Managers
{
    public class FileManager : IFileManager
    {
        public FileManager(ILogger logger)
        {
            _logger = logger;
        }

        private readonly ILogger _logger;

        #region Interface Impl

        public Stream OpenRead(string filename)
        {
            try
            {
                return File.OpenRead(filename);
            }
            catch (Exception e)
            {
                _logger.Log(Verbosity.Error, "Error when reading file: " + filename + ". Message: " + e.Message);
            }
            return null;
        }

        public Stream OpenWrite(string filename)
        {
            try
            {
                return File.OpenWrite(filename);
            }
            catch (Exception e)
            {
                _logger.Log(Verbosity.Error, "Error when reading file: " + filename + ". Message: " + e.Message);
            }

            return null;
        }

        #endregion
    }
}
