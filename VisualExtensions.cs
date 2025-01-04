using System.Collections;

namespace UnityEngine.Extensions
{
    public static class VisualExtensions
    {
        #region Animator

        /// <summary>
        /// Gets the current or next AnimatorStateInfo for the specified layer.
        /// </summary>
        /// <param name="animator">The Animator instance.</param>
        /// <param name="layer">The Animator layer index.</param>
        /// <returns>The current or next AnimatorStateInfo.</returns>
        public static AnimatorStateInfo GetStateInfo(this Animator animator, int layer)
        {
            AnimatorStateInfo state = animator.GetNextAnimatorStateInfo(layer);

            if (state.shortNameHash != 0)
            {
                return state;
            }

            return animator.GetCurrentAnimatorStateInfo(layer);
        }

        /// <summary>
        /// Waits for the animation on layer 0 to complete.
        /// </summary>
        /// <param name="animator">The Animator instance.</param>
        /// <returns>An IEnumerator for coroutine execution.</returns>
        public static IEnumerator Wait(this Animator animator)
        {
            return animator.Wait(0);
        }

        /// <summary>
        /// Waits for the animation on the specified layer to complete.
        /// </summary>
        /// <param name="animator">The Animator instance.</param>
        /// <param name="layer">The Animator layer index.</param>
        /// <returns>An IEnumerator for coroutine execution.</returns>
        public static IEnumerator Wait(this Animator animator, int layer)
        {
            WaitForEndOfFrame delay = new WaitForEndOfFrame();
            yield return delay;

            AnimatorStateInfo state = animator.GetStateInfo(layer);
            int initialStateHash = state.shortNameHash;

            if (state.length == 0)
            {
                yield break;
            }

            while (state.normalizedTime < 1f)
            {
                yield return delay;

                state = animator.GetStateInfo(layer);

                if (initialStateHash != state.shortNameHash)
                {
                    break;
                }
            }
        }

        #endregion

        #region Color

        /// <summary>
        /// Converts a Color to a hexadecimal string in RGBA format.
        /// </summary>
        /// <param name="color">The Color to convert.</param>
        /// <returns>A hexadecimal string representation of the Color.</returns>
        public static string ToHex(this Color color)
        {
            return ColorUtility.ToHtmlStringRGBA(color);
        }

        /// <summary>
        /// Converts a hexadecimal string to a Color.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>A Color represented by the hexadecimal string.</returns>
        public static Color ToColor(this string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out var result);
            return result;
        }

        #endregion

        #region Material

        /// <summary>
        /// Tries to set a float property on the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="value">The float value to set.</param>
        /// <returns>True if the property exists and was set; otherwise, false.</returns>
        public static bool TrySetFloat(this Material material, int propertyId, float value)
        {
            if (!material.HasProperty(propertyId))
            {
                return false;
            }

            material.SetFloat(propertyId, value);
            return true;
        }

        /// <summary>
        /// Tries to set a Color property on the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="color">The Color value to set.</param>
        /// <returns>True if the property exists and was set; otherwise, false.</returns>
        public static bool TrySetColor(this Material material, int propertyId, Color color)
        {
            if (!material.HasProperty(propertyId))
            {
                return false;
            }

            material.SetColor(propertyId, color);
            return true;
        }

        /// <summary>
        /// Tries to set a Texture property on the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="texture">The Texture value to set.</param>
        /// <returns>True if the property exists and was set; otherwise, false.</returns>
        public static bool TrySetTexture(this Material material, int propertyId, Texture texture)
        {
            if (!material.HasProperty(propertyId))
            {
                return false;
            }

            material.SetTexture(propertyId, texture);
            return true;
        }

        /// <summary>
        /// Tries to get a float property from the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="value">The output float value.</param>
        /// <returns>True if the property exists and was retrieved; otherwise, false.</returns>
        public static bool TryGetFloat(this Material material, int propertyId, out float value)
        {
            if (!material.HasProperty(propertyId))
            {
                value = default;
                return false;
            }

            value = material.GetFloat(propertyId);
            return true;
        }

        /// <summary>
        /// Tries to get a Color property from the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="color">The output Color value.</param>
        /// <returns>True if the property exists and was retrieved; otherwise, false.</returns>
        public static bool TryGetColor(this Material material, int propertyId, out Color color)
        {
            if (!material.HasProperty(propertyId))
            {
                color = default;
                return false;
            }

            color = material.GetColor(propertyId);
            return true;
        }

        /// <summary>
        /// Tries to get a Texture property from the Material.
        /// </summary>
        /// <param name="material">The Material instance.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="texture">The output Texture value.</param>
        /// <returns>True if the property exists and was retrieved; otherwise, false.</returns>
        public static bool TryGetTexture(this Material material, int propertyId, out Texture texture)
        {
            if (!material.HasProperty(propertyId))
            {
                texture = default;
                return false;
            }

            texture = material.GetTexture(propertyId);
            return true;
        }

        #endregion
    }
}