using System;
using System.Collections;
using MMFramework;
using UnityEngine;
namespace MMGame
{
    public class BulletLauncher : MonoBehaviour
    {
        public Transform bulletparent;
        public static float GetPysicsDown(Transform shoot, Transform owner, float angle)
        {
            Vector2 d = shoot.transform.position - owner.transform.position;
            float dy = d.y;// - d.x * Mathf.Sin(AngleTools.AngleToRadian(angle));
            return dy;
        }
        public void Launch(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            // Debug.Log("BulletLauncher.Launch" + fireID);
            AudioModule.Instance.Sound_Fire(fireID);
            FireData firedata = FireData.GetData(fireID);
            FireStrategyModel strategy = (FireStrategyModel)(int)firedata.StrategyType;
            if (strategy == FireStrategyModel.NONE)
            {
                //None
                Debug.Log("Fire: None");
            }
            else if (strategy == FireStrategyModel.SPEED)
            {
                RootModule.Instance.StartCoroutine(Speed(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.CIRCLE)
            {
                RootModule.Instance.StartCoroutine(Circle(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.CUT)
            {
                RootModule.Instance.StartCoroutine(Cut(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.CIRCLE_SPEED)
            {
                RootModule.Instance.StartCoroutine(CircleSpeed(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.PLACE_FIRE)
            {
                RootModule.Instance.StartCoroutine(PlaceFire(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.STAB_ROW)
            {
                RootModule.Instance.StartCoroutine(STAB_ROW(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.YunShi)
            {
                RootModule.Instance.StartCoroutine(YunShi(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.Shining)
            {
                RootModule.Instance.StartCoroutine(Shining(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.ROAD)
            {
                RootModule.Instance.StartCoroutine(Road(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.HUTI)
            {
                RootModule.Instance.StartCoroutine(CA_Huti(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.NET1)
            {
                RootModule.Instance.StartCoroutine(HU_NET1(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.NET2)
            {
                RootModule.Instance.StartCoroutine(HU_NET2(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.NET3)
            {
                RootModule.Instance.StartCoroutine(HU_NET3(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.MAGICBALL)
            {
                RootModule.Instance.StartCoroutine(MAGICBALL(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.RAIN)
            {
                RootModule.Instance.StartCoroutine(YunShi(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.TRAP)
            {
                RootModule.Instance.StartCoroutine(Trap(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.THROW)
            {
                RootModule.Instance.StartCoroutine(Throw(fireID, staticcarry, dynamiccarry));
            }
            else if (strategy == FireStrategyModel.MULTI_SECTORS)
            {
                RootModule.Instance.StartCoroutine(Multi_Sectors(fireID, staticcarry, dynamiccarry));
            }
        }
        /*
         * 向一个方向发射,可以有 0数量 1速度 2偏移 3时间隔 4延迟 5随机散射角
         * */
        IEnumerator Speed(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);

            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            float num = firedata.StrategyArray[0];
            float dspeed = firedata.StrategyArray[1];
            float start_distance = firedata.StrategyArray[2];
            //相隔时间
            float interval_t = firedata.StrategyArray[3];
            float delay = firedata.StrategyArray[4]; //整体delay
            float randomr = firedata.StrategyArray[5]; //随机偏移角度
            //生成

            yield return new WaitForSeconds(delay);

            for (int i = 0; i < num; i++)
            {
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                float finalr = fire_angle + RandomTools.Range(-randomr, randomr);
                float up = staticcarry.up;

                //位置和角度
                float dx = start_distance * Mathf.Cos(AngleTools.AngleToRadian(fire_angle));
                float dy = start_distance * Mathf.Sin(AngleTools.AngleToRadian(fire_angle));
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                go.transform.localPosition = new Vector2(pos.x + dx, pos.y + dy - up);
                //go.transform.localRotation = AngleTools.AngleToRotation(finalr);

                //初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetQuaternion(AngleTools.AngleToRotation(finalr));

                //运动
                Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                float fx = dspeed * Mathf.Cos(AngleTools.AngleToRadian(finalr));
                float fy = dspeed * Mathf.Sin(AngleTools.AngleToRadian(finalr));
                rigid.velocity = new Vector2(fx, fy);
                yield return new WaitForSeconds(interval_t);
            }

        }
        /*
         * 放置一个不动的子弹 0偏移(可由STAB_ROW代替)
         * */
        IEnumerator PlaceFire(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            float center_distance = firedata.StrategyArray[0];
            //生成
            GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

            //位置和角度
            float up = staticcarry.up;
            float dx = center_distance * Mathf.Cos(AngleTools.AngleToRadian(fire_angle));
            float dy = center_distance * Mathf.Sin(AngleTools.AngleToRadian(fire_angle));
            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            go.transform.localPosition = new Vector2(pos.x + dx, pos.y + dy - up);

            //初始化
            go.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
            bullet.SetShowUp(up);
            bullet.SetQuaternion(AngleTools.AngleToRotation(fire_angle));

            //无运动

            yield return new WaitForEndOfFrame();
        }
        /*
         * 放置一排不动的子弹 0个数 1第一个的距离 2距间隔 3时间隔 4保持正角
         ***/
        IEnumerator STAB_ROW(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;
            //个数
            float num = firedata.StrategyArray[0];
            //第一个的距离
            float start_d = firedata.StrategyArray[1];
            //相隔距离
            float interval_d = firedata.StrategyArray[2];
            //相隔时间
            float interval_t = firedata.StrategyArray[3];
            //角度保持
            bool keep_rotate = firedata.StrategyArray[4] > 0 ? true : false;

            float startx = Mathf.Cos(AngleTools.AngleToRadian(fire_angle)) * start_d;
            float starty = Mathf.Sin(AngleTools.AngleToRadian(fire_angle)) * start_d;
            float dx = Mathf.Cos(AngleTools.AngleToRadian(fire_angle)) * interval_d;
            float dy = Mathf.Sin(AngleTools.AngleToRadian(fire_angle)) * interval_d;
            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            for (int i = 0; i < num; i++)
            {
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                float x = startx + dx * i;
                float y = starty + dy * i;
                float up = staticcarry.up;
                go.transform.localPosition = pos + new Vector3(x, y - up);
                //DebugTool.LogError("冰刺:owner" + staticcarry.Owner.transform.localPosition + " pos" + pos + "+(" + x + "," + y + "-" + up + ")=" + go.transform.localPosition);
                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);

                if (!keep_rotate)
                {
                    bullet.transform.localEulerAngles = Vector3.zero;
                    bullet.SetQuaternion(AngleTools.AngleToRotation(fire_angle));

                }

                //5运动
                if (interval_t > 0)
                    yield return new WaitForSeconds(interval_t);
            }
        }
        /*
         * 砍 0偏移 1保持正角
         ***/
        IEnumerator Cut(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            float center_distance = firedata.StrategyArray[0];
            bool keep_rotate = firedata.StrategyArray[1] > 0 ? true : false;
            //生成
            Transform bullet_parent = firedata.WithBody ? shoottrans : bulletparent;
            GameObject go = BulletPool.Instance.Spawn(bullet_parent, firedata.BulletID);

            if (firedata.WithBody) go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            //初始化
            float up = staticcarry.up;
            go.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
            bullet.SetShowUp(up);

            float show_angle = fire_angle;
            float posangle = fire_angle;
            if (firedata.WithBody && AngleTools.IsLeft(fire_angle))
            {
                posangle = 180 - fire_angle;
            }

            //位置和角度
            //DebugTool.LogError("angle: " + show_angle);
            float dx = center_distance * Mathf.Cos(AngleTools.AngleToRadian(posangle));
            float dy = center_distance * Mathf.Sin(AngleTools.AngleToRadian(posangle));
            //Debug.Log(bullet_parent == null);
            //Debug.Log(shoottrans == null);
            Vector3 pos = bullet_parent.InverseTransformPoint(shoottrans.position);
            go.transform.localPosition = new Vector2(pos.x + dx, pos.y + dy - up);
            // Debug.LogError(bullet_parent.name + " " + go.transform.localPosition.x + ", " + go.transform.localPosition.y);
            if (!keep_rotate)
                bullet.SetQuaternion(AngleTools.AngleToRotation(show_angle));
            else
                go.transform.localScale = new Vector3(
                    go.transform.localScale.x * (AngleTools.IsLeft(fire_angle) ? -1f : 1f),
                    go.transform.localScale.y,
                    go.transform.localScale.z
                );

            //无运动

            yield return new WaitForEndOfFrame();
        }
        /*
         * 圆放置 0数量 1半径 2时间间隔 3初始角偏移 4角间隔
         ***/
        IEnumerator Circle(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //0数量 1半径 2时间间隔 3初始角偏移 4角间隔
            float num = firedata.StrategyArray[0];
            float R = firedata.StrategyArray[1];
            float interval_t = firedata.StrategyArray[2];
            float interval_angle = firedata.StrategyArray[3];
            float delay = firedata.StrategyArray[4];

            yield return new WaitForSeconds(delay);

            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            float start_angle = fire_angle;
            for (int i = 0; i < num; i++)
            {
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                float skill_angle = start_angle + interval_angle * i;
                float up = staticcarry.up;
                float x = Mathf.Cos(AngleTools.AngleToRadian(skill_angle)) * R;
                float y = Mathf.Sin(AngleTools.AngleToRadian(skill_angle)) * R;
                go.transform.localPosition = pos + new Vector3(x, y - up);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);

                //5运动
                if (interval_t > 0)
                    yield return new WaitForSeconds(interval_t);
            }
        }
        /*
         * 砍 0数量 1数据 1数量 2半径 3时间间隔 4初始角偏移 5角间隔
         ***/
        IEnumerator CircleSpeed(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2半径 3时间间隔 4初始角偏移 5角间隔 6子弹速度
            float num = firedata.StrategyArray[0];
            float R = firedata.StrategyArray[1];
            float interval_t = firedata.StrategyArray[2];
            float start_angle_offset = firedata.StrategyArray[3];
            float interval_angle = firedata.StrategyArray[4];
            float speed = firedata.StrategyArray[5];

            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            float start_angle = fire_angle + start_angle_offset;
            for (int i = 0; i < num; i++)
            {
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                float skill_angle = start_angle + interval_angle * i;
                float up = staticcarry.up;
                float x = Mathf.Cos(AngleTools.AngleToRadian(skill_angle)) * R;
                float y = Mathf.Sin(AngleTools.AngleToRadian(skill_angle)) * R;
                go.transform.localPosition = pos + new Vector3(x, y - up);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetQuaternion(AngleTools.AngleToRotation(skill_angle));

                //5运动
                Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                float fx = speed * Mathf.Cos(AngleTools.AngleToRadian(skill_angle));
                float fy = speed * Mathf.Sin(AngleTools.AngleToRadian(skill_angle));
                rigid.velocity = new Vector2(fx, fy);

                yield return new WaitForSeconds(interval_t);
            }
        }
        IEnumerator YunShi(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2半径 3时间间隔
            float num = firedata.StrategyArray[0];
            float R = firedata.StrategyArray[1];
            float interval_t = firedata.StrategyArray[2];
            float up = staticcarry.up;

            for (int i = 0; i < num; i++)
            {
                float r = RandomTools.Range(0, 360);
                float d = RandomTools.Range(0, R);
                Debug.Log("fireID" + fireID + "=" + i + " " + r + " " + d + " " + R + " " + interval_t + " " + num);
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);

                //3位置和角度
                float x = Mathf.Cos(AngleTools.AngleToRadian(r)) * d;
                float y = Mathf.Sin(AngleTools.AngleToRadian(r)) * d;
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                go.transform.localPosition = pos + new Vector3(x, y - up);

                //5运动
                yield return new WaitForSeconds(interval_t);
            }
        }
        IEnumerator Shining(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1半径
            float R = firedata.StrategyArray[0];
            int maxgeneration = (int)firedata.StrategyArray[1];

            if (dynamiccarry.Generation > maxgeneration)
                yield return new WaitForEndOfFrame();
            else
            {
                float r = RandomTools.Range(0, 360);
                float d = RandomTools.Range(0, R);
                float up = staticcarry.up;
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                float x = Mathf.Cos(AngleTools.AngleToRadian(r)) * d;
                float y = Mathf.Sin(AngleTools.AngleToRadian(r)) * d;
                go.transform.localPosition = pos + new Vector3(x, y - up);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetSelfcontinue();
                //5运动
                yield return new WaitForEndOfFrame();
            }

        }
        IEnumerator Road(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2时间间隔
            float num = firedata.StrategyArray[0];
            float interval_t = firedata.StrategyArray[1];

            yield return new WaitForSeconds(0.5f);
            float up = staticcarry.up;
            for (int i = 0; i < num; i++)
            {
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);

                //3位置和角度
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                pos.y -= up;
                go.transform.localPosition = pos;

                //5运动
                yield return new WaitForSeconds(interval_t);
            }
        }

        IEnumerator CA_Huti(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据
            float y = firedata.StrategyArray[0];
            //2生成
            //string prefab_pathname = ConfigInGame.BulletPrefabPathName;
            //GameObject go = ToolsInGame.CreatePrefab(shoottrans, prefab_pathname);
            GameObject go = BulletPool.Instance.Spawn(shoottrans, firedata.BulletID);

            float up = staticcarry.up;

            //4初始化
            go.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
            bullet.SetShowUp(up);
            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            //3位置和角度
            //Vector3 pos = bulletparent.InverseTransformPoint(trans.position);
            go.transform.localPosition = new Vector3(0, y - up, 0);

            //5运动
            yield return new WaitForEndOfFrame();
        }

        IEnumerator HU_NET1(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2总共角度
            float num = firedata.StrategyArray[0];
            float totalangle = firedata.StrategyArray[1];
            float perangle = totalangle / ((totalangle > 180) ? num : (num - 1));
            float firstangle = fire_angle - (totalangle / 2);
            float up = staticcarry.up;

            for (int i = 0; i < num; i++)
            {
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                pos.y -= up;
                go.transform.localPosition = pos;

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetQuaternion(AngleTools.AngleToRotation(firstangle + perangle * i));
            }

            //5运动
            yield return new WaitForEndOfFrame();
        }

        IEnumerator HU_NET2(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2总共角度
            float num = firedata.StrategyArray[0];
            float totalangle = firedata.StrategyArray[1];
            float speed = firedata.StrategyArray[2];
            float perangle = totalangle / ((totalangle > 180) ? num : (num - 1));
            float firstangle = fire_angle - (totalangle / 2);

            for (int i = 0; i < num; i++)
            {
                float toangle = firstangle + perangle * i;
                float up = staticcarry.up;

                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                pos.y -= up;
                go.transform.localPosition = pos;

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetQuaternion(AngleTools.AngleToRotation(toangle));

                //5运动
                Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                float fx = speed * Mathf.Cos(AngleTools.AngleToRadian(toangle));
                float fy = speed * Mathf.Sin(AngleTools.AngleToRadian(toangle));
                rigid.velocity = new Vector2(fx, fy);
            }

            yield return new WaitForEndOfFrame();
        }

        IEnumerator HU_NET3(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 1数量 2总共角度
            float num = firedata.StrategyArray[0];
            float totalangle = firedata.StrategyArray[1];
            float speed = firedata.StrategyArray[2];
            float perangle = totalangle / ((totalangle > 180) ? num : (num - 1));
            float firstangle = fire_angle - (totalangle / 2);

            for (int i = 0; i < num; i++)
            {
                float toangle = firstangle + perangle * i;
                float up = staticcarry.up;
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //3位置和角度
                Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                pos.y -= up;
                go.transform.localPosition = pos;

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);
                bullet.SetQuaternion(AngleTools.AngleToRotation(toangle));

                //5运动
                Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                float fx = speed * Mathf.Cos(AngleTools.AngleToRadian(toangle));
                float fy = speed * Mathf.Sin(AngleTools.AngleToRadian(toangle));
                rigid.velocity = new Vector2(fx, fy);
            }

            yield return new WaitForEndOfFrame();
        }
        IEnumerator MAGICBALL(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            // Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            ////1数据 1数量 2总共角度
            float num = firedata.StrategyArray[0];
            float R = firedata.StrategyArray[1];
            float anglespeed = firedata.StrategyArray[2];
            float perangle = 360 / num;
            for (int i = 0; i < num; i++)
            {
                float toangle = perangle * i;
                float up = staticcarry.up;
                //2生成
                GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                //4初始化
                go.GetComponent<BulletTest>().GenerateBullet();
                Bullet bullet = go.GetComponent<Bullet>();
                bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                bullet.SetShowUp(up);

                //5运动
                Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                rigid.bodyType = RigidbodyType2D.Kinematic;
                CircleMove circlemove = go.AddComponent<CircleMove>();
                circlemove.SetInit(R, anglespeed, toangle);
            }

            yield return new WaitForEndOfFrame();
        }
        IEnumerator Trap(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            float y = firedata.StrategyArray[0];
            //生成
            GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);
            float up = staticcarry.up;

            //初始化
            go.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
            bullet.SetShowUp(up);

            //位置和角度
            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            go.transform.localPosition = pos + new Vector3(y, y - up);

            //无运动

            yield return new WaitForEndOfFrame();
        }
        IEnumerator Throw(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            float dspeed = firedata.StrategyArray[0];
            float start_distance = firedata.StrategyArray[1];
            //生成

            GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

            float finalr = fire_angle;
            float up = staticcarry.up;

            //初始化
            go.GetComponent<BulletTest>().GenerateBullet();
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
            bullet.SetShowUp(up);

            //位置和角度
            float dx = start_distance * Mathf.Cos(AngleTools.AngleToRadian(fire_angle));
            float dy = start_distance * Mathf.Sin(AngleTools.AngleToRadian(fire_angle));
            Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
            go.transform.localPosition = new Vector2(pos.x + dx, pos.y + dy - up);

            //运动
            Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
            float fx = dspeed * Mathf.Cos(AngleTools.AngleToRadian(finalr));
            float fy = dspeed * Mathf.Sin(AngleTools.AngleToRadian(finalr));
            rigid.velocity = new Vector2(fx, fy);

            yield return new WaitForEndOfFrame();
        }

        IEnumerator Multi_Sectors(int fireID, BulletStaticCarry staticcarry, BulletDynamicCarry dynamiccarry)
        {
            FireData firedata = FireData.GetData(fireID);
            Transform shoottrans = dynamiccarry.Shoottans;

            float fire_angle = dynamiccarry.Angle;

            //1数据 0数量 1总共角度 2速度 3批次 4批次间隔
            float num = firedata.StrategyArray[0];
            float totalangle = firedata.StrategyArray[1];
            float speed = firedata.StrategyArray[2];
            float perangle = totalangle / ((totalangle > 180) ? num : (num - 1));
            float firstangle = fire_angle - (totalangle / 2);
            float count = firedata.StrategyArray[3];
            float interval = firedata.StrategyArray[4];

            for (int t = 0; t < count; t++)
            {
                for (int i = 0; i < num; i++)
                {
                    float toangle = firstangle + perangle * i;
                    float up = staticcarry.up;
                    //2生成
                    GameObject go = BulletPool.Instance.Spawn(bulletparent, firedata.BulletID);

                    //4初始化
                    go.GetComponent<BulletTest>().GenerateBullet();
                    Bullet bullet = go.GetComponent<Bullet>();
                    bullet.InitBullet(firedata.BulletID, staticcarry, dynamiccarry);
                    bullet.SetShowUp(up);
                    bullet.SetQuaternion(AngleTools.AngleToRotation(toangle));
                    //3位置和角度
                    Vector3 pos = bulletparent.InverseTransformPoint(shoottrans.position);
                    pos.y -= up;
                    go.transform.localPosition = pos;
                    //go.transform.localRotation = AngleTools.AngleToRotation(toangle);

                    //5运动
                    Rigidbody2D rigid = go.GetComponent<Rigidbody2D>();
                    float fx = speed * Mathf.Cos(AngleTools.AngleToRadian(toangle));
                    float fy = speed * Mathf.Sin(AngleTools.AngleToRadian(toangle));
                    rigid.velocity = new Vector2(fx, fy);
                }

                yield return new WaitForSeconds(interval);
            }
        }
    }
}