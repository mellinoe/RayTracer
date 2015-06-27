// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using RayTracer.Objects;
using System.Collections.Generic;
#if SCALAR
using UnoptimizedVectors;
#else
using System.Numerics;
#endif

namespace RayTracer
{
    /// <summary>
    /// Represents an intersection of a ray with an object.
    /// </summary>
    public struct Intersection
    {
        /// <summary>
        /// The point at which the intersection occurred
        /// </summary>
        public readonly Vector3 Point;
        /// <summary>
        /// The surface's normal at the intersection point
        /// </summary>
        public readonly Vector3 Normal;
        /// <summary>
        /// The direction the ray was traveling on impact.
        /// </summary>
        public readonly Vector3 ImpactDirection;
        /// <summary>
        /// The object that was hit
        /// </summary>
        public DrawableSceneObject ObjectHit;
        /// <summary>
        /// The color of the object hit at the intersection
        /// </summary>
        public readonly Color Color;
        /// <summary>
        /// The distance at which the intersection occurred.
        /// </summary>
        public readonly float Distance;

        /// <summary>
        /// Constructs an intersection
        /// </summary>
        /// <param name="point">The point at which the intersection occurred</param>
        /// <param name="normal">The normal direction at which the intersection occurred</param>
        /// <param name="impactDirection">The direction the ray was traveling on impact</param>
        /// <param name="obj">The object that was intersected</param>
        /// <param name="color">The object's raw color at the intersection point</param>
        /// <param name="distance">The distance from the ray's origin that the intersection occurred</param>
        public Intersection(Vector3 point, Vector3 normal, Vector3 impactDirection, DrawableSceneObject obj, Color color, float distance)
        {
            this.Point = point;
            this.Normal = normal;
            this.ImpactDirection = impactDirection;
            this.ObjectHit = obj;
            this.Color = color;
            this.Distance = distance;
        }

        /// <summary>
        /// Returns the closest intersection in a list of intersections.
        /// </summary>
        public static Intersection GetClosestIntersection(List<Intersection> list)
        {
            var closest = list[0].Distance;
            var closestIntersection = list[0];
            for (int g = 1; g < list.Count; g++)
            {
                var item = list[g];
                if (item.Distance < closest)
                {
                    closest = item.Distance;
                    closestIntersection = item;
                }
            }

            return closestIntersection;
        }
    }
}
