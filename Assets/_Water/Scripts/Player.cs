using UnityEngine;

namespace com.IsartDigital.Water._Water.Scripts
{
    public class Player : MonoBehaviour
    {
        private InputSystem_Actions inputSystem;

        [SerializeField]
        private Vector2 MinMaxPos;
        [SerializeField]
        private float SideSpeed = 100;

        [SerializeField] private GameObject[] particles;


        private void Start()
        {
            inputSystem = new();
            inputSystem.Enable();

            Initialisation();
        }

        private void Update()
        {
            if (!GameManager.IsPlaying)
                return;

            Move(inputSystem.Player.Move.ReadValue<Vector2>().x);
        }

        public void SpawnParticles()
        {
            foreach (GameObject particle in particles)
                particle.SetActive(true);
        }

        private void Initialisation()
        {
            SetXPosition((MinMaxPos.y - MinMaxPos.x) / 2 + MinMaxPos.x);
        }

        private void Move(float dir)
        {
            float newPos = Mathf.Clamp(transform.position.x + (dir * SideSpeed * Time.deltaTime), MinMaxPos.x,
                MinMaxPos.y);
            SetXPosition(newPos);
        }

        private  void SetXPosition(float newXValue) =>
            transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
        private  void SetYPosition(float newYValue) =>
            transform.position = new Vector3(transform.position.x, newYValue, transform.position.z);

        private void OnDestroy()
        {
            inputSystem.Disable();
        }
    }
}
