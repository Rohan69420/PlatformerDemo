using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayTester
    {
        private GameObject testObject;
        private Movement mover;

        //setup
        [SetUp]
        public void Setup()
        {
            testObject = GameObject.Instantiate(new GameObject());
            testObject.AddComponent<Rigidbody2D>(); //add rigidbody2d
            mover = testObject.AddComponent<Movement>();
        }

        // A Test behaves as an ordinary method
        [Test]
        public void PassChecker()
        {
            //Default PlayMode tester: should always pass
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ComponentTesterRigidBody2D()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.1f);
            Assert.NotNull(mover.GetComponent<Rigidbody2D>(), "Mover has a rigid 2d body attached");
        }

        [UnityTest]
        public IEnumerator DynamicObjectTester()
        {
            Vector2 position = mover.transform.position;
           
            //wait a bit 
            yield return new WaitForSeconds(0.1f);

            Vector2 newPosition = mover.transform.position;

            Assert.AreNotEqual(position, newPosition);
        }

        //ensure we are always running a new instance of the gameobject
        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(testObject);
        }
    }
}
