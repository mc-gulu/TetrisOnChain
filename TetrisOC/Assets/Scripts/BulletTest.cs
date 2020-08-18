using UnityEngine;
namespace MMGame
{
    [ExecuteInEditMode]
    public class BulletTest : MonoBehaviour
    {
        public void GenerateBullet()
        {
            Bullet bullet = GetComponent<Bullet>();
            if (bullet == null)
                bullet = gameObject.AddComponent<Bullet>();

            Rigidbody2D rigid = GetComponent<Rigidbody2D>();
            if (rigid == null)
                rigid = gameObject.AddComponent<Rigidbody2D>();

            BulletLauncher launcher = GetComponent<BulletLauncher>();
            if (launcher == null)
                launcher = gameObject.AddComponent<BulletLauncher>();

            rigid.gravityScale = 0;
            bullet.rigid = rigid;
            bullet.launcher = launcher;
            bullet.boxtrans = transform.Find("box");
            bullet.spritepoint = transform.Find("spritepoint");

            bullet.animator = GetComponent<Animator>();
        }
        void Update()
        {
            var spritepoint = transform.Find("spritepoint");
            Vector3 v = spritepoint.eulerAngles;
            // Debug.Log(v.x + ",  " + v.y + ",  " + v.z);
            float angle = v.z;

            ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>(true);
            if (ps.Length > 0 && spritepoint != null)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    // ps[i].main.startRotationX.mode = ParticleSystemCurveMode.Constant;
                    ps[i].startRotation = -MMFramework.AngleTools.AngleToRadian(angle);
                }
            }
        }
    }
}