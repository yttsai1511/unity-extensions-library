using System;

namespace UnityEngine.Extensions
{
    public static class GameObjectExtensions
    {
        #region GameObject

        /// <summary>
        /// Gets the sibling index of the GameObject in its parent's hierarchy.
        /// </summary>
        /// <param name="gameObject">The GameObject to query.</param>
        /// <returns>The sibling index of the GameObject.</returns>
        public static int GetSiblingIndex(this GameObject gameObject)
        {
            return gameObject.transform.GetSiblingIndex();
        }

        /// <summary>
        /// Instantiates a copy of the specified object and preserves its name.
        /// </summary>
        /// <typeparam name="TSource">The type of the object to instantiate.</typeparam>
        /// <param name="source">The source object to instantiate.</param>
        /// <returns>A new instance of the object.</returns>
        public static TSource Instantiate<TSource>(this TSource source)
            where TSource : Object
        {
            TSource instance = Object.Instantiate(source);
            instance.name = source.name;
            return instance;
        }

        /// <summary>
        /// Instantiates a copy of the specified object under an optional parent transform.
        /// </summary>
        /// <typeparam name="TSource">The type of the object to instantiate.</typeparam>
        /// <param name="source">The source object to instantiate.</param>
        /// <param name="parent">The optional parent Transform for the new instance.</param>
        /// <param name="instantiateInWorldSpace">Whether to instantiate the object in world space.</param>
        /// <returns>A new instance of the object.</returns>
        public static TSource Instantiate<TSource>(this TSource source, Transform parent, bool instantiateInWorldSpace = false)
            where TSource : Object
        {
            TSource instance = Object.Instantiate(source, parent, instantiateInWorldSpace);
            instance.name = source.name;
            return instance;
        }

        /// <summary>
        /// Instantiates a copy of the specified object at a specific position and rotation under an optional parent transform.
        /// </summary>
        /// <typeparam name="TSource">The type of the object to instantiate.</typeparam>
        /// <param name="source">The source object to instantiate.</param>
        /// <param name="position">The position to instantiate the object at.</param>
        /// <param name="rotation">The rotation to instantiate the object with.</param>
        /// <param name="parent">The optional parent Transform for the new instance.</param>
        /// <returns>A new instance of the object.</returns>
        public static TSource Instantiate<TSource>(this TSource source, Vector3 position, Quaternion rotation, Transform parent = null)
            where TSource : Object
        {
            TSource instance = Object.Instantiate(source, position, rotation, parent);
            instance.name = source.name;
            return instance;
        }

        /// <summary>
        /// Resets the local position, rotation, and scale of the GameObject's Transform to default values.
        /// </summary>
        /// <param name="gameObject">The GameObject to reset.</param>
        public static void ResetLocal(this GameObject gameObject)
        {
            gameObject.transform.ResetLocal();
        }

        /// <summary>
        /// Sets the anchor values of the GameObject's RectTransform.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="anchorMin">The minimum anchor value.</param>
        /// <param name="anchorMax">The maximum anchor value.</param>
        public static void SetAnchor(this GameObject gameObject, Vector2 anchorMin, Vector2 anchorMax)
        {
            gameObject.transform.SetAnchor(anchorMin, anchorMax);
        }

        /// <summary>
        /// Sets the GameObject as the first sibling in its parent's hierarchy.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        public static void SetAsFirstSibling(this GameObject gameObject)
        {
            gameObject.transform.SetAsFirstSibling();
        }

        /// <summary>
        /// Sets the GameObject as the last sibling in its parent's hierarchy.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        public static void SetAsLastSibling(this GameObject gameObject)
        {
            gameObject.transform.SetAsLastSibling();
        }

        /// <summary>
        /// Sets the GameObject's layer by name.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="layerName">The name of the layer to set.</param>
        public static void SetLayer(this GameObject gameObject, string layerName)
        {
            gameObject.layer = LayerMask.NameToLayer(layerName);
        }

        /// <summary>
        /// Sets the offset values of the GameObject's RectTransform.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="offsetMin">The minimum offset value.</param>
        /// <param name="offsetMax">The maximum offset value.</param>
        public static void SetOffset(this GameObject gameObject, Vector2 offsetMin, Vector2 offsetMax)
        {
            gameObject.transform.SetOffset(offsetMin, offsetMax);
        }

        /// <summary>
        /// Sets the parent of the GameObject's Transform.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="parentTransform">The Transform to set as the parent.</param>
        public static void SetParent(this GameObject gameObject, Transform parentTransform)
        {
            gameObject.transform.SetParent(parentTransform);
        }

        /// <summary>
        /// Sets the position and rotation of the GameObject's Transform.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="position">The position to set.</param>
        /// <param name="rotation">The rotation to set.</param>
        public static void SetPositionAndRotation(this GameObject gameObject, Vector3 position, Quaternion rotation)
        {
            gameObject.transform.SetPositionAndRotation(position, rotation);
        }

        /// <summary>
        /// Sets the sibling index of the GameObject in its parent's hierarchy.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="index">The sibling index to set.</param>
        public static void SetSiblingIndex(this GameObject gameObject, int index)
        {
            gameObject.transform.SetSiblingIndex(index);
        }

        /// <summary>
        /// Tries to add a component of the specified type to the GameObject.
        /// </summary>
        /// <typeparam name="TSource">The type of the component to add.</typeparam>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <returns>The newly added or existing component of the specified type.</returns>
        public static TSource TryAddComponent<TSource>(this GameObject gameObject)
            where TSource : Component
        {
            return gameObject.TryAddComponent(typeof(TSource)) as TSource;
        }

        /// <summary>
        /// Tries to add a component of the specified type to the GameObject.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="type">The type of the component to add.</param>
        /// <returns>The newly added or existing component of the specified type.</returns>
        public static Component TryAddComponent(this GameObject gameObject, Type type)
        {
            bool hasComponent = gameObject.TryGetComponent(type, out var existingComponent);

            if (!hasComponent)
            {
                existingComponent = gameObject.AddComponent(type);
            }

            return existingComponent;
        }

        /// <summary>
        /// Sets the active state of the GameObject only if the state is different from the current state.
        /// </summary>
        /// <param name="gameObject">The GameObject to modify.</param>
        /// <param name="isActive">The active state to set.</param>
        public static void TrySetActive(this GameObject gameObject, bool isActive)
        {
            if (gameObject.activeSelf != isActive)
            {
                gameObject.SetActive(isActive);
            }
        }

        #endregion

        #region RectTransform

        /// <summary>
        /// Sets the width and height of the RectTransform using current anchors.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to modify.</param>
        /// <param name="width">The width to set.</param>
        /// <param name="height">The height to set.</param>
        public static void SetSizeWithCurrentAnchors(this RectTransform rectTransform, float width, float height)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        /// <summary>
        /// Sets the size of the RectTransform using a Vector2 for width and height.
        /// </summary>
        /// <param name="rectTransform">The RectTransform to modify.</param>
        /// <param name="size">The size to set as a Vector2 (x for width, y for height).</param>
        public static void SetSizeWithCurrentAnchors(this RectTransform rectTransform, Vector2 size)
        {
            rectTransform.SetSizeWithCurrentAnchors(size.x, size.y);
        }

        #endregion

        #region Transform

        /// <summary>
        /// Resets the local position, rotation, and scale of the Transform to default values.
        /// </summary>
        /// <param name="transform">The Transform to reset.</param>
        public static void ResetLocal(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Sets the anchor values of the RectTransform.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="anchorMin">The minimum anchor position.</param>
        /// <param name="anchorMax">The maximum anchor position.</param>
        public static void SetAnchor(this Transform transform, Vector2 anchorMin, Vector2 anchorMax)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.anchorMin = anchorMin;
                rectTransform.anchorMax = anchorMax;
            }
        }

        /// <summary>
        /// Sets the layer of the GameObject associated with the Transform.
        /// </summary>
        /// <param name="transform">The Transform whose GameObject's layer to modify.</param>
        /// <param name="layerName">The name of the layer to set.</param>
        public static void SetLayer(this Transform transform, string layerName)
        {
            transform.gameObject.SetLayer(layerName);
        }

        /// <summary>
        /// Sets the offset of the RectTransform.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="offsetMin">The minimum offset.</param>
        /// <param name="offsetMax">The maximum offset.</param>
        public static void SetOffset(this Transform transform, Vector2 offsetMin, Vector2 offsetMax)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.offsetMin = offsetMin;
                rectTransform.offsetMax = offsetMax;
            }
        }

        /// <summary>
        /// Sets the size delta of the RectTransform using width and height values.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="width">The width to set.</param>
        /// <param name="height">The height to set.</param>
        public static void SetSizeDelta(this Transform transform, float width, float height)
        {
            transform.SetSizeDelta(new Vector2(width, height));
        }

        /// <summary>
        /// Sets the size delta of the RectTransform using a Vector2 for width and height.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="size">The size to set as a Vector2 (x for width, y for height).</param>
        public static void SetSizeDelta(this Transform transform, Vector2 size)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.sizeDelta = size;
            }
        }

        /// <summary>
        /// Sets the size of the RectTransform along a specific axis using current anchors.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="axis">The axis to modify (Horizontal or Vertical).</param>
        /// <param name="value">The size value to set.</param>
        public static void SetSizeWithCurrentAnchors(this Transform transform, RectTransform.Axis axis, float value)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.SetSizeWithCurrentAnchors(axis, value);
            }
        }

        /// <summary>
        /// Sets the width and height of the RectTransform using current anchors.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="width">The width to set.</param>
        /// <param name="height">The height to set.</param>
        public static void SetSizeWithCurrentAnchors(this Transform transform, float width, float height)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.SetSizeWithCurrentAnchors(width, height);
            }
        }

        /// <summary>
        /// Sets the size of the RectTransform using a Vector2 for width and height.
        /// </summary>
        /// <param name="transform">The Transform to modify. Must be a RectTransform.</param>
        /// <param name="size">The size to set as a Vector2 (x for width, y for height).</param>
        public static void SetSizeWithCurrentAnchors(this Transform transform, Vector2 size)
        {
            if (transform is RectTransform rectTransform)
            {
                rectTransform.SetSizeWithCurrentAnchors(size);
            }
        }

        #endregion
    }
}