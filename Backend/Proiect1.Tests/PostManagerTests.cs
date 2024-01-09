using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Managers;
using Proiect1.DAL;
using Proiect1.DAL.Entities;

namespace Proiect1.Tests;

public class PostManagerTests : IClassFixture<PostManagerFixture>
{
    private readonly PostManagerFixture _fixture;

    public PostManagerTests(PostManagerFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetAllUserPosts_ShouldReturnListOfPosts()
    {
        // Arrange
        var userId = 1;
        var expectedPosts = new List<Post>
        {
            new Post
            {
                UserId = userId,
                Description = "Test Description 1",
                ImagePath = "TestImagePath 1",
                UserName = "TestUser",
                PublishDate = DateTime.Now
            },
            new Post
            {
                UserId = userId,
                Description = "Test Description 2",
                ImagePath = "TestImagePath 2",
                UserName = "TestUser",
                PublishDate = DateTime.Now
            }
        };

        _fixture.PostRepositoryMock.Setup(repo => repo.GetAllUserPostsIQueryable(userId)).Returns(expectedPosts.AsQueryable());

        // Act
        var result = _fixture.PostManager.GetAllUserPosts(userId);

        // Assert
        Assert.Equal(expectedPosts, result);
    }

    [Fact]
    public void GetAllPosts_ShouldReturnListOfPosts()
    {
        // Arrange
        var expectedPosts = new List<Post>
        {
            new Post
            {
                UserId = 1,
                Description = "Test Description 1",
                ImagePath = "TestImagePath 1",
                UserName = "TestUser",
                PublishDate = DateTime.Now
            },
            new Post
            {
                UserId = 2,
                Description = "Test Description 2",
                ImagePath = "TestImagePath 2",
                UserName = "TestUser",
                PublishDate = DateTime.Now
            }
        };

        _fixture.PostRepositoryMock.Setup(repo => repo.GetAllPostsIQueryable()).Returns(expectedPosts.AsQueryable());

        // Act
        var result = _fixture.PostManager.GetAllPosts();

        // Assert
        Assert.Equal(expectedPosts, result);
    }
}

public class PostManagerFixture
{
    public Mock<IPostRepository> PostRepositoryMock { get; }
    public Mock<IUserRepository> UserRepositoryMock { get; }
    public IPostManager PostManager { get; }
    public AppDbContext db;

    public PostManagerFixture()
    {
        var postRepositoryMock = new Mock<IPostRepository>();
        var userRepositoryMock = new Mock<IUserRepository>();
        postRepositoryMock.Setup(repo => repo.CreatePost(It.IsAny<Post>()));
        userRepositoryMock.Setup(repo => repo.GetAllUsersToList());
        PostManager = new PostManager(postRepositoryMock.Object, userRepositoryMock.Object, db);
    }
}

