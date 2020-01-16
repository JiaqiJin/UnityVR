namespace UnityEngine
{
    using System.Collections.Generic;
    using System.Linq;
    //clase de extension de camara
    public static class CameraExtensions
    {
        public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer renderer)
        {
            if (renderer == null) return false;
            return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderer.bounds);
        }
        //Devuelve verdadero si los límites están dentro de la matriz plana.
        //La función TestPlanesAABB usa la matriz Plane para probar si un cuadro delimitador está en el tronco o no.
        public static bool IsObjectVisible(this UnityEngine.Camera @this, Renderer[] renderers)
        {
            if (renderers == null || renderers.Length <= 0) return false;
            //calculateFrustrumPlanes para probar si la vista de una cámara contiene un objeto, independientemente de si se representa o no.
            return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), renderers.EncapsulatedBounds());
        }
    }
    //https://forum.unity.com/threads/c-renderer-bounds-and-meshfilter-mesh-bounds-returning-different-sizes.222390/
    //El volumen delimitador del renderizador
    // el tamaño de un objeto que también incluya a sus hijos.
    public static class BoundsExtensions
    {
        public static Bounds EncapsulatedBounds(this IEnumerable<Renderer> renderers)
        {
            return renderers.Select(renderer => renderer.bounds).Encapsulation();
        }

        public static Bounds EncapsulatedBounds(this IEnumerable<Mesh> meshes)
        {
            return meshes.Select(mesh => mesh.bounds).Encapsulation();
        }

        public static Bounds Encapsulation(this IEnumerable<Bounds> bounds)
        {
            return bounds.Aggregate((encapsulation, next) =>
            {
                encapsulation.Encapsulate(next);
                return encapsulation;
            });
        }
    }
}