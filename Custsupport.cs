using NUnit.Framework;
using Project2p4.Controllers;
using Project2p4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using NuGet.ContentModel;

namespace Custsupport.Tests
{
    [TestFixture]
    public class UserInfoesControllerTests
    {
        [Test]
        public void user_GetUserId_ReturnsUserId()
        {
            // Arrange
            var user = new user { UserId = 1 };

            // Act
            int userId = user.UserId;

            // Assert
            Assert.AreEqual(1, userId);
        }

        [Test]
        public void user_SetUserId_CanSetUserId()
        {
            // Arrange
            var user = new user();

            // Act
            user.UserId = 2;

            // Assert
            Assert.AreEqual(2, user.UserId);
        }

        [Test]
        public void Custlog_GetLogId_ReturnsLogId()
        {
            // Arrange
            var custLogInfo = new Custlog { LogId = 1 };

            // Act
            int logId = custLogInfo.LogId;

            // Assert
            Assert.AreEqual(1, logId);
        }

        [Test]
        public void Custlog_SetLogId_CanSetLogId()
        {
            // Arrange
            var custLogInfo = new Custlog();

            // Act
            custLogInfo.LogId = 2;

            // Assert
            Assert.AreEqual(2, custLogInfo.LogId);
        }
    }
}