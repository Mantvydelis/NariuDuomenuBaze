using Microsoft.EntityFrameworkCore;
using Moq;
using NariuDuomenuBaze.Core.Contracts;
using NariuDuomenuBaze.Core.Models;
using NariuDuomenuBaze.Core.Repositories;
using NariuDuomenuBaze.Core.Services;

namespace MemberTests
{
    public class MemberServiceTests
    {
        [Fact]
        public async Task AddMember_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            var member = new Member { Id = 1, Name = "Petras", Surname = "Petraitis" };

            // Act
            await memberService.AddMember(member);

            // Assert
            mockEfRepository.Verify(x => x.AddMember(It.IsAny<Member>()), Times.Once);
            mockFileRepository.Verify(x => x.AddMember(It.IsAny<Member>()), Times.Once);
        }


        [Fact]
        public async Task DeleteMemberById_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            int memberId = 1;

            // Act
            await memberService.DeleteMemberById(memberId);

            // Assert
            mockEfRepository.Verify(x => x.DeleteMemberById(memberId), Times.Once);
            mockFileRepository.Verify(x => x.DeleteMemberById(memberId), Times.Once);
        }

        [Fact]
        public async Task DeleteMemberBySurname_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            string surname = "Petraitis";

            // Act
            await memberService.DeleteMemberBySurname(surname);

            // Assert
            mockEfRepository.Verify(x => x.DeleteMemberBySurname(surname), Times.Once);
            mockFileRepository.Verify(x => x.DeleteMemberBySurname(surname), Times.Once);
        }

        [Fact]
        public async Task GetAllMembers_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            var expectedMembers = new List<Member>
            {
            new Member { Id = 1, Name = "Petras", Surname = "Petraitis" },
            new Member { Id = 2, Name = "Jonas", Surname = "Jonaitis" }
            };

            mockEfRepository.Setup(x => x.GetAllMembers()).ReturnsAsync(expectedMembers);

            // Act
            var result = await memberService.GetAllMembers();

            // Assert
            Assert.Equal(expectedMembers, result);
            mockEfRepository.Verify(x => x.GetAllMembers(), Times.Once);
        }

        [Fact]
        public async Task GetMemberBySurname_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            string surname = "Petraitis";
            var expectedMember = new Member { Id = 1, Name = "Petras", Surname = "Petraitis" };

            mockEfRepository.Setup(x => x.GetMemberBySurname(surname)).ReturnsAsync(expectedMember);

            // Act
            var result = await memberService.GetMemberBySurname(surname);

            // Assert
            Assert.Equal(expectedMember, result);
            mockEfRepository.Verify(x => x.GetMemberBySurname(surname), Times.Once);
        }

        [Fact]
        public async Task UpdateMember_Test()
        {
            // Arrange
            var mockEfRepository = new Mock<IMemberEfDbRepository>();
            var mockFileRepository = new Mock<IMemberFileRepository>();
            var memberService = new MemberService(mockEfRepository.Object, mockFileRepository.Object);
            var member = new Member { Id = 1, Name = "Petras", Surname = "Petraitis" };

            // Act
            await memberService.UpdateMember(member);

            // Assert
            mockEfRepository.Verify(x => x.UpdateMember(It.IsAny<Member>()), Times.Once);
            mockFileRepository.Verify(x => x.UpdateMember(It.IsAny<Member>()), Times.Once);
        }



    }


}