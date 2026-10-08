using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeelteKoolV2.ApplicationServices.Services
{
    public class LecturersServices : ILecturersServices
    {
        public Task<Lecturer> Create(LecturerDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<Lecturer> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Lecturer> DetailAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Lecturer> Update(LecturerDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
