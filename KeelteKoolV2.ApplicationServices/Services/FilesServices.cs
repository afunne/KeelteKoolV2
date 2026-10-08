using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeelteKoolV2.ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        public Task<FileToDatabase> RemoveFileFromDatabase(FileToDatabaseDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<FileToDatabase> RemoveFilesFromDatabase(FileToDatabaseDTO[] dtos)
        {
            throw new NotImplementedException();
        }

        public void UploadFiles(LecturerDTO dto, Lecturer domain)
        {
            throw new NotImplementedException();
        }
    }
}
