using App.Metrics.Data;
using FluentAssertions;
using Xunit;

namespace App.Metrics.Facts.Metrics
{
    public class CounterValueSetItemTests
    {
        [Fact]
        public void can_determine_if_are_same()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);
            var second = new CounterValue.SetItem("first", 10L, 100.0);

            first.Should().Be(second);
        }

        [Fact]
        public void can_determine_if_diff()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);
            var second = new CounterValue.SetItem("second", 10L, 100.0);

            first.Should().NotBe(second);
        }

        [Fact]
        public void can_determine_if_diff_using_operator()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);
            var second = new CounterValue.SetItem("second", 10L, 100.0);

            Assert.True(first != second);
        }

        [Fact]
        public void can_determine_if_same_using_operator()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);
            var second = new CounterValue.SetItem("first", 10L, 100.0);

            Assert.True(first == second);
        }

        [Fact]
        public void hash_codes_differ_between_instances()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0).GetHashCode();
            var second = new CounterValue.SetItem("second", 10L, 100.0).GetHashCode();

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void hash_codes_same_for_same_instance()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);

            var second = first;

            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }

        [Fact]
        public void if_counts_diff_not_the_same()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0).GetHashCode();
            var second = new CounterValue.SetItem("first", 5L, 100.0).GetHashCode();

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void if_percentage_diff_not_the_same()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0).GetHashCode();
            var second = new CounterValue.SetItem("first", 10L, 80.0).GetHashCode();

            Assert.NotEqual(first, second);
        }

        [Fact]
        public void reference_equality_should_be_correct()
        {
            var first = new CounterValue.SetItem("first", 10L, 100.0);
            var second = new CounterValue.SetItem("second", 10L, 100.0);

            Assert.False(first.Equals((object)second));
        }
    }
}