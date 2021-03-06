﻿using System;
using PublicApiGeneratorTests.Examples;
using Xunit;

namespace PublicApiGeneratorTests
{
    public class Interface_events : ApiGeneratorTestsBase
    {
        [Fact]
        public void Should_output_event()
        {
            // TODO: CodeDOM outputs "public" in event declarations in interfaces
            // This looks like a bug? That's what the implementation does, but it's
            // not valid C#...
            AssertPublicApi<ISimpleEvent>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface ISimpleEvent
    {
        public event System.EventHandler Event;
    }
}");
        }

        [Fact]
        public void Should_output_event_with_generics()
        {
            AssertPublicApi<IGenericEventHandler>(
@"namespace PublicApiGeneratorTests.Examples
{
    public interface IGenericEventHandler
    {
        public event System.EventHandler<System.EventArgs> Event;
    }
}");
        }
    }

    // ReSharper disable EventNeverSubscribedTo.Global
    namespace Examples
    {
        public interface ISimpleEvent
        {
            event EventHandler Event;
        }

        public interface IGenericEventHandler
        {
            event EventHandler<EventArgs> Event;
        }
    }
    // ReSharper restore EventNeverSubscribedTo.Global
}