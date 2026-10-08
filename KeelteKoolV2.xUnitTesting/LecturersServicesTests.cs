using KeelteKoolV2.Core.Domain;
using KeelteKoolV2.Core.DTO;
using KeelteKoolV2.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KeelteKoolV2.xUnitTesting
{
    public class LecturersServicesTests : TestBase
    {
        [Fact]
        public async Task Should_AddNewLecturer_WhenResultISReturned()
        {
            //ülesseade
            LecturerDTO dto = new LecturerDTO();
            dto.FirstName = "Test";
            dto.LastName = "Test";
            dto.Qualifications = "Testicles";
            dto.UserID = "TestUser";
            //dto.Image = 

            //tegevus
            var result = await Svc<ILecturersServices>().Create(dto);

            //kontroll
            Assert.NotNull(result);
        }

        //details test
        [Fact]
        public async Task Should_ReturnLecturerDetails_WhenGuidIsNotNull()
        {
            //ülesseade
            Lecturer createdLecturer = await AddObjectToDB();

            //tegevus
            //kasutame objektis asuvat id et see objekt tagasi lugeda andmebaasist DetailAsync meetodiga
            var result = await Svc<ILecturersServices>().DetailAsync(createdLecturer.Id);

            //kontroll
            //kontrollime et tagastati midagi
            Assert.NotNull(result);
            //kontrollime et tagastatud objekti id on sama nagu see mis andmebaasi lisatud sai
            Assert.Equal(createdLecturer.Id, result.Id);
            Assert.Equal(createdLecturer.FirstName, result.FirstName);
            Assert.Equal(createdLecturer.LastName, result.LastName);
            Assert.Equal(createdLecturer.Qualifications, result.Qualifications);
        }

        //update test
        [Fact]
        public async Task Should_UpdateLecturerWithNewData_WhenDataIsDifferentFromDB()
        {
            //ülesseade
            Lecturer createdLecturer = await AddObjectToDB();

            var dto = new LecturerDTO();
            dto.Id = createdLecturer.Id;
            dto.FirstName = "Muudetud";
            dto.LastName = "Õpetaja";
            dto.Qualifications = "Magister";
            dto.UserID = createdLecturer.UserID;
            dto.CreatedAt = createdLecturer.CreatedAt;
            dto.ModifiedAt = DateTime.Now;

            //tegevus
            var result = await Svc<ILecturersServices>().Update(dto);

            //kontroll
            Assert.NotNull(result);
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.FirstName, result.FirstName);
            Assert.Equal(dto.LastName, result.LastName);
            Assert.Equal(dto.Qualifications, result.Qualifications);
            Assert.Equal(createdLecturer.CreatedAt, result.CreatedAt);
        }

        //delete test
        [Fact]
        public async Task Should_DeleteLecturerFromDB_WhenValidIDIsGiven()
        {
            //ülesseade
            Lecturer createdLecturer = await AddObjectToDB();

            //tegevus
            var deletedLecturer = await Svc<ILecturersServices>().Delete(createdLecturer.Id);
            var result = await Svc<ILecturersServices>().DetailAsync(createdLecturer.Id);

            //kontroll
            Assert.Null(result);
            Assert.NotNull(deletedLecturer);
            Assert.Equal(createdLecturer.Id, deletedLecturer.Id);
        }

        private async Task<Lecturer> AddObjectToDB()
        {
            //tekitame uue objekti ja lisame andmebaasi
            LecturerDTO lecturer = MockLecturerDTOData();
            return await Svc<ILecturersServices>().Create(lecturer);
        }

        private LecturerDTO MockLecturerDTOData()
        {
            return new LecturerDTO
            {
                FirstName = "Test",
                LastName = "Test",
                Qualifications = "Testicles",
                UserID = "TestUser",
            };
        }
    }
}
