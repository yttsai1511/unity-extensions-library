using System;

namespace UnityEngine.Extensions
{
    public static class ComponentExtensions
    {
        #region Behaviour

        /// <summary>
        /// Restarts the specified Behaviour by disabling and re-enabling it.
        /// </summary>
        /// <param name="behaviour">The Behaviour instance to restart.</param>
        public static void Restart(this Behaviour behaviour)
        {
            behaviour.enabled = false;
            behaviour.enabled = true;
        }

        /// <summary>
        /// Sets the active state of the specified Behaviour.
        /// </summary>
        /// <param name="behaviour">The Behaviour instance to modify.</param>
        /// <param name="isActive">A boolean indicating whether the Behaviour should be enabled.</param>
        public static void SetActive(this Behaviour behaviour, bool isActive)
        {
            behaviour.enabled = isActive;
        }

        #endregion

        #region Component

        /// <summary>
        /// Determines if the specified Component is null or its GameObject is null.
        /// </summary>
        /// <param name="component">The Component instance to check.</param>
        /// <returns>Returns true if the Component or its GameObject is null; otherwise, false.</returns>
        public static bool IsNull(this Component component)
        {
            if (component == null)
            {
                return true;
            }

            if (component.gameObject == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Attempts to add a component of the specified type to the GameObject of the given Component.
        /// If the component already exists, it returns the existing instance.
        /// </summary>
        /// <typeparam name="TComponent">The type of the Component to add.</typeparam>
        /// <param name="component">The Component whose GameObject will receive the new Component.</param>
        /// <returns>Returns the newly added or existing Component of the specified type.</returns>
        public static TComponent TryAddComponent<TComponent>(this Component component)
            where TComponent : Component
        {
            return component.TryAddComponent(typeof(TComponent)) as TComponent;
        }

        /// <summary>
        /// Attempts to add a component of the specified type to the GameObject of the given Component.
        /// If the component already exists, it returns the existing instance.
        /// </summary>
        /// <param name="component">The Component whose GameObject will receive the new Component.</param>
        /// <param name="type">The type of the Component to add.</param>
        /// <returns>Returns the newly added or existing Component of the specified type.</returns>
        public static Component TryAddComponent(this Component component, Type type)
        {
            bool hasComponent = component.TryGetComponent(type, out var existingComponent);

            if (!hasComponent)
            {
                existingComponent = component.gameObject.AddComponent(type);
            }

            return existingComponent;
        }

        #endregion
    }
}