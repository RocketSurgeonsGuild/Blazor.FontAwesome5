using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Bunit;
using Bunit.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using EC = Microsoft.AspNetCore.Components.EventCallback;

namespace Rocket.Surgery.Blazor.FontAwesome5.Tests
{
    /// <summary>
    /// Base class for test classes that contains XUnit Razor component tests.
    /// </summary>
    public static class ComponentParameterHelpers
    {
        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value
        /// for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback(string name, Action callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback(string name, Action<object> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback(string name, Func<Task> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback(string name, Func<object, Task> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback<TValue>(string name, Action callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback<TValue>(string name, Action<TValue> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback<TValue>(string name, Func<Task> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(null, callback));

        /// <summary>
        /// Creates a <see cref="ComponentParameter"/> with an <see cref="Microsoft.AspNetCore.Components.EventCallback"/> as parameter value for this <see cref="TestContext"/> and
        /// <paramref name="callback"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="callback">The event callback.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter EventCallback<TValue>(string name, Func<TValue, Task> callback)
            => ComponentParameter.CreateParameter(name, EC.Factory.Create<TValue>(null, callback));

        /// <summary>
        /// Creates a component parameter which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value or null of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter Parameter(string name, object? value)
            => ComponentParameter.CreateParameter(name, value);

        /// <summary>
        /// Creates a cascading value which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Value of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter CascadingValue(string name, object value)
            => ComponentParameter.CreateCascadingValue(name, value);

        /// <summary>
        /// Creates a cascading value which can be passed to a test contexts render methods.
        /// </summary>
        /// <param name="value">Value of the parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter CascadingValue(object value)
            => ComponentParameter.CreateCascadingValue(null, value);

        /// <summary>
        /// Creates a ChildContent <see cref="Microsoft.AspNetCore.Components.RenderFragment"/> with the provided
        /// <paramref name="markup"/> as rendered output.
        /// </summary>
        /// <param name="markup">Markup to pass to the child content parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter ChildContent(string markup) => RenderFragment(nameof(ChildContent), markup);

        /// <summary>
        /// Creates a ChildContent <see cref="Microsoft.AspNetCore.Components.RenderFragment"/> which will render a <typeparamref name="TComponent"/> component
        /// with the provided <paramref name="parameters"/> as input.
        /// </summary>
        /// <typeparam name="TComponent">The type of the component to render with the <see cref="Microsoft.AspNetCore.Components.RenderFragment"/></typeparam>
        /// <param name="parameters">Parameters to pass to the <typeparamref name="TComponent"/>.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter ChildContent<TComponent>(params ComponentParameter[] parameters)
            where TComponent : class, IComponent => RenderFragment<TComponent>(nameof(ChildContent), parameters);

        /// <summary>
        /// Creates a <see cref="Microsoft.AspNetCore.Components.RenderFragment"/> with the provided
        /// <paramref name="markup"/> as rendered output and passes it to the parameter specified in <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="markup">Markup to pass to the render fragment parameter</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter RenderFragment(string name, string markup)
            => ComponentParameter.CreateParameter(name, markup.ToMarkupRenderFragment());

        /// <summary>
        /// Creates a <see cref="Microsoft.AspNetCore.Components.RenderFragment"/> which will render a <typeparamref name="TComponent"/> component
        /// with the provided <paramref name="parameters"/> as input, and passes it to the parameter specified in <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="TComponent">The type of the component to render with the <see cref="Microsoft.AspNetCore.Components.RenderFragment"/></typeparam>
        /// <param name="name">Parameter name.</param>
        /// <param name="parameters">Parameters to pass to the <typeparamref name="TComponent"/>.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter RenderFragment<TComponent>(string name, params ComponentParameter[] parameters)
            where TComponent : class, IComponent => ComponentParameter.CreateParameter(
            name,
            new ComponentParameterCollection { parameters }.ToRenderFragment<TComponent>()
        );

        /// <summary>
        /// Creates a component parameter which will pass the <paramref name="template"/> <see cref="Microsoft.AspNetCore.Components.RenderFragment{TValue}" />
        /// to the parameter with the name <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="TValue">The value used to build the content.</typeparam>
        /// <param name="name">Parameter name.</param>
        /// <param name="template"><see cref="Microsoft.AspNetCore.Components.RenderFragment{TValue}" /> to pass to the parameter.</param>
        /// <returns>The <see cref="ComponentParameter"/>.</returns>
        public static ComponentParameter Template<TValue>(string name, RenderFragment<TValue> template)
            => ComponentParameter.CreateParameter(name, template);
    }

    public interface IRenderFragmentBuilder
    {
        IRenderFragmentBuilder Markup(string markup);

        IRenderFragmentBuilder RenderComponent<T>(Action<IComponentBuilder<T>> builderCallback)
            where T : class, IComponent;
    }

    public class RenderFragmentBuilder : IRenderFragmentBuilder
    {
        private readonly List<RenderFragment> _renderFragments = new List<RenderFragment>();

        public IRenderFragmentBuilder Markup(string markup)
        {
            _renderFragments.Add(markup.ToMarkupRenderFragment());
            return this;
        }

        public IRenderFragmentBuilder RenderComponent<T>(Action<IComponentBuilder<T>> builderCallback)
            where T : class, IComponent
        {
            var builder = new ComponentBuilder<T>();
            builderCallback(builder);
            _renderFragments.Add(builder.ToRenderFragment());
            return this;
        }

        public RenderFragment ToRenderFragment()
        {
            return renderTree =>
            {
                var index = 0;
                foreach (var renderFragment in _renderFragments)
                    renderTree.AddContent(index++, renderFragment);
            };
        }
    }

    public interface IComponentBuilder<TComponent>
        where TComponent : class, IComponent
    {
        IComponentBuilder<TComponent> Parameter<T>(Expression<Func<TComponent, T>> expression, T value);

        IComponentBuilder<TComponent> EventCallback(
            Expression<Func<TComponent, EventCallback>> expression,
            Action callback
        );

        IComponentBuilder<TComponent> EventCallback(
            Expression<Func<TComponent, EventCallback>> expression,
            Func<Task> callback
        );

        IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Action callback
        );

        IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Action<T> callback
        );

        IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Func<Task> callback
        );

        IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Func<T, Task> callback
        );

        IComponentBuilder<TComponent> ChildContent(string markup);
        IComponentBuilder<TComponent> ChildContent(Action<RenderFragmentBuilder> builderCallback);

        IComponentBuilder<TComponent> RenderFragment<T>(
            Expression<Func<TComponent, RenderFragment<T>>> expression,
            Action<IComponentBuilder<T>> builderCallback
        )
            where T : class, IComponent;

        IComponentBuilder<TComponent> RenderFragment(
            Expression<Func<TComponent, RenderFragment>> expression,
            string markup
        );

        IComponentBuilder<TComponent> RenderFragment(
            Expression<Func<TComponent, RenderFragment>> expression,
            Action<RenderFragmentBuilder> renderFragmentBuilder
        );

        IComponentBuilder<TComponent> CascadingValue(string name, object value);
        IComponentBuilder<TComponent> CascadingValue(object value);
    }

    public class ComponentBuilder<TComponent> : IComponentBuilder<TComponent>
        where TComponent : class, IComponent
    {
        private readonly List<ComponentParameter> _componentParameters = new List<ComponentParameter>();

        public IComponentBuilder<TComponent> Parameter<T>(Expression<Func<TComponent, T>> expression, T value)
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(ComponentParameter.CreateParameter(propertyName, value));
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback(
            Expression<Func<TComponent, EventCallback>> expression,
            Action callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback(
            Expression<Func<TComponent, EventCallback>> expression,
            Func<Task> callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Action callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create<T>(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Action<T> callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Func<Task> callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create<T>(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> EventCallback<T>(
            Expression<Func<TComponent, EventCallback<T>>> expression,
            Func<T, Task> callback
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(propertyName, EC.Factory.Create(null, callback))
            );
            return this;
        }

        public IComponentBuilder<TComponent> ChildContent(string markup)
        {
            _componentParameters.Add(
                ComponentParameter.CreateParameter(nameof(ChildContent), markup.ToMarkupRenderFragment())
            );
            return this;
        }

        public IComponentBuilder<TComponent> ChildContent(Action<RenderFragmentBuilder> builderCallback)
        {
            var renderFragmentBuilder = new RenderFragmentBuilder();
            builderCallback(renderFragmentBuilder);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(nameof(ChildContent), renderFragmentBuilder.ToRenderFragment())
            );
            return this;
        }

        public IComponentBuilder<TComponent> RenderFragment<T>(
            Expression<Func<TComponent, RenderFragment<T>>> expression,
            Action<IComponentBuilder<T>> builderCallback
        )
            where T : class, IComponent
        {
            var propertyName = GetPropertyName(expression);
            var builder = new ComponentBuilder<T>();
            builderCallback(builder);
            _componentParameters.Add(
                ComponentParameter.CreateParameter(
                    propertyName,
                    builder.ToRenderFragment()
                )
            );
            return this;
        }

        public IComponentBuilder<TComponent> RenderFragment(
            Expression<Func<TComponent, RenderFragment>> expression,
            string markup
        )
        {
            var propertyName = GetPropertyName(expression);
            _componentParameters.Add(ComponentParameter.CreateParameter(propertyName, markup.ToMarkupRenderFragment()));
            return this;
        }

        public IComponentBuilder<TComponent> RenderFragment(
            Expression<Func<TComponent, RenderFragment>> expression,
            Action<RenderFragmentBuilder> renderFragmentBuilder
        )
        {
            var propertyName = GetPropertyName(expression);
            var builder = new RenderFragmentBuilder();
            renderFragmentBuilder(builder);
            _componentParameters.Add(ComponentParameter.CreateParameter(propertyName, builder.ToRenderFragment()));
            return this;
        }

        public IComponentBuilder<TComponent> CascadingValue(string name, object value)
        {
            _componentParameters.Add(ComponentParameter.CreateCascadingValue(name, value));
            return this;
        }

        public IComponentBuilder<TComponent> CascadingValue(object value)
        {
            _componentParameters.Add(ComponentParameter.CreateCascadingValue(null, value));
            return this;
        }

        private string GetPropertyName<T>(Expression<Func<TComponent, T>> expression)
        {
            if (!( expression.Body is MemberExpression member ))
            {
                throw new ArgumentException(
                    string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        expression
                    )
                );
            }

            if (!( member.Member is PropertyInfo propertyInfo ))
            {
                throw new ArgumentException(
                    string.Format(
                        "Expression '{0}' refers to a field, not a property.",
                        expression
                    )
                );
            }

            if (typeof(TComponent) != propertyInfo.ReflectedType &&
                !typeof(TComponent).IsSubclassOf(propertyInfo.ReflectedType))
            {
                throw new ArgumentException(
                    string.Format(
                        "Expression '{0}' refers to a property that is not from type {1}.",
                        expression,
                        typeof(TComponent)
                    )
                );
            }

            return propertyInfo.Name;
        }

        public RenderFragment ToRenderFragment()
            => new ComponentParameterCollection() { _componentParameters }.ToRenderFragment<TComponent>();

        public IReadOnlyList<ComponentParameter> Parameters => _componentParameters.AsReadOnly();
    }

    public static class TestContextExtensions
    {
        public static RenderTreeBuilder RenderComponent<TComponent>(
            this RenderTreeBuilder treeBuilder,
            Action<IComponentBuilder<TComponent>> builderCallback
        )
            where TComponent : class, IComponent
        {
            var builder = new ComponentBuilder<TComponent>();
            builderCallback(builder);
            builder.ToRenderFragment()(treeBuilder);
            return treeBuilder;
        }
    }
}
