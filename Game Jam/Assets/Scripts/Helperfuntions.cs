using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Helper
{

    public static class Helpers
    {

        // Camera
        private static Camera _camera;
        public static Camera MainCamera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }




        // Mouse and Positions
        public static Vector2 GetWorldPosition(Vector2 screenPosition, Camera camera)
        {
            Vector2 worldPos = camera.ScreenToWorldPoint(screenPosition);
            return worldPos;
        }
        public static Vector2 GetScreenPosition(Vector2 worldPosition, Camera camera)
        {
            Vector2 screenPos = camera.WorldToScreenPoint(worldPosition);
            return screenPos;
        }
        public static Vector3 Get3dScreenPosition(Vector3 worldPosition, Camera camera)
        {
            Vector3 screenPos = camera.WorldToScreenPoint(worldPosition);
            return screenPos;
        }

        // Rotations

        public static float Get2DRotationAngle(Vector3 position, Vector3 mouseWorldPos)
        {
            Vector3 dif = mouseWorldPos - position;
            float angle = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg - 90f;
            return angle;
        }


        //Clamping
        public static void ClampTransformBasedOnFrameSize(Transform target, Camera cam)
        {
            float width = cam.aspect * cam.orthographicSize;
            float height = cam.orthographicSize;
            target.position = new Vector3(
                Mathf.Clamp(target.position.x, -width, width),
                Mathf.Clamp(target.position.y, -height, height));
        }
        public static void ClampTransformBasedOnFrameSize(Transform target, Camera cam, out float _width, out float _height)
        {
            float width = cam.aspect * cam.orthographicSize;
            float height = cam.orthographicSize;
            target.position = new Vector3(
                Mathf.Clamp(target.position.x, -width, width),
                Mathf.Clamp(target.position.y, -height, height));

            _width = width;
            _height = height;
        }
        public static void ClampWithExtraSpace(Transform target, Camera cam, float x, float y)
        {

            float width = cam.aspect * cam.orthographicSize - x;
            float height = cam.orthographicSize - y;

            target.position = new Vector3(
                Mathf.Clamp(target.position.x, -width, width),
                Mathf.Clamp(target.position.y, -height, height));

        }
        public static void ClampWithExtraSpace(Transform target, Camera cam, float x, float y, out float _width, out float _height)
        {

            float width = cam.aspect * cam.orthographicSize - x;
            float height = cam.orthographicSize - y;

            target.position = new Vector3(
                Mathf.Clamp(target.position.x, -width, width),
                Mathf.Clamp(target.position.y, -height, height));

            _width = width;
            _height = height;
        }

        // Hide Cursor
        public static void HideCursor(CursorLockMode lockmode, bool visible)
        {
            Cursor.lockState = lockmode;
            Cursor.visible = visible;
        }



        // getting randomPosition
        public static Vector3 GetRandomVector(Vector3 min, Vector3 max)
        {
            float x = Random.Range(min.x, max.y);
            float y = Random.Range(min.y, max.y);
            float z = Random.Range(min.z, max.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 GetRandomDirection()
        {
            return new Vector3(
                GetRandomDirectionfloat, GetRandomDirectionfloat, GetRandomDirectionfloat
                ).normalized;
        }

        public static float GetRandomDirectionfloat
        {
            get
            {
                return Random.Range(-1f, 1f);
            }
        }


        // scenes
        public static void ReloadScene(InputAction action)
        {
            var activeSceneName = SceneManager.GetActiveScene().name;
            if (action.triggered)
            {
                SceneManager.LoadSceneAsync(activeSceneName);
                Debug.Log(activeSceneName);
            }
        }

        //3d
        public static Vector3 Get3dClickPoint(Plane plane, Vector3 ScreenPosition, Camera camera, bool debug = false)
        {
            Ray ray = camera.ScreenPointToRay(ScreenPosition);
            if (plane.Raycast(ray, out float rayLength))
            {
                Vector3 Result;
                Result = ray.GetPoint(rayLength);
                if (debug)
                {
                    Debug.DrawRay(ray.origin, Result, Color.blue);
                }
                return Result;
            }
            else return Vector3.zero;
        }

    }
}