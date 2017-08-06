using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.FileProviders;
using NSubstitute;
using Tests.BroadbandDeals.Core.Services;
using Xunit;

namespace Tests.BroadbandDeals.Core.Tests
{
    public class DealServiceTests : IClassFixture<FileFixture>
    {
        private readonly FileFixture _fileFixture;

        public DealServiceTests(FileFixture fileFixture)
        {
            _fileFixture = fileFixture ?? throw new ArgumentNullException(nameof(fileFixture));
        }
        
        [Fact]
        public async Task Should_GetAllAsync_ReturnsACorrectNumberOfDeals_WhenDealFileIsAvailable()
        {
            //Given
            var fileInfo = Substitute.For<IFileInfo>();
            fileInfo.Exists.Returns(true);
            fileInfo.CreateReadStream().Returns(_fileFixture.Stream);
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.GetFileInfo(Arg.Any<string>()).Returns(fileInfo);
            
            var sut = new DealService(fileProvider);
            
            //When
            var actual = await sut.GetAllAsync();

            //Then
            actual.Should().NotBeNull();
            actual.Should().HaveCount(7);
        }
        
        [Fact]
        public void Should_GetAllAsync_ThrowsFileNotFoundException_WhenDealFileIsNotAvailable()
        {
            //Given
            var fileInfo = Substitute.For<IFileInfo>();
            fileInfo.Exists.Returns(false);
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.GetFileInfo(Arg.Any<string>()).Returns(fileInfo);
            
            var sut = new DealService(fileProvider);
            
            //When
            Func<Task> action = async () => await sut.GetAllAsync();

            //Then
            action.ShouldThrow<FileNotFoundException>();
        }
    }
}
