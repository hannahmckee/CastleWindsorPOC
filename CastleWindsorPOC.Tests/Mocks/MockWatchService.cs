using System;
using CastleWindsorPOC.Domain.Interfaces;
using Moq;

namespace CastleWindsorPOC.Tests.Mocks
{
    internal sealed class MockWatchService
    {
        private readonly Mock<IWatchService> _service;
        private string _currentDate;

        public MockWatchService()
        {
            _service = new Mock<IWatchService>();
            _currentDate = "Today";
        }

        public MockWatchService WithCurrentDate(string date)
        {
            _currentDate = date;
            return this;
        }

        public Mock<IWatchService> Build()
        {
            _service
                .Setup(s => s.GetTime())
                .Returns(_currentDate);

            return _service;
        }
    }
}
