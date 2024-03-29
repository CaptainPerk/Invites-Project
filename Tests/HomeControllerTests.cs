using System;
using System.Collections.Generic;
using PartyInvites.Controllers;
using PartyInvites.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void ListActionFiltersNonAttendees()
        {
            //Arrange
            var controller = new HomeController(new FakeRepository());

            //Act
            var result = controller.ListResponses();

            //Assert
            Assert.Equal(2, (result.Model as IEnumerable<GuestResponse>).Count());
        }
    }

    class FakeRepository : IRepository
    {
        public IEnumerable<GuestResponse> Responses => new List<GuestResponse>
            {
                new GuestResponse { Name = "Bob", WillAttend = true },
                new GuestResponse { Name = "Alice", WillAttend = true},
                new GuestResponse { Name = "Joe", WillAttend = false}
            };
        
        public void AddResponse(GuestResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
