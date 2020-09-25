using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Text;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    /// <summary>
    /// This class demonstrates how to query input data either by using InputUtils or
    /// by directly accessing InteractionMappings from all active controllers.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Examples/InputDataExample")]
    public class ControllerTest : MonoBehaviour
    {

        private Tuple<InputSourceType, Handedness>[] inputSources = new Tuple<InputSourceType, Handedness>[]
        {
            new Tuple<InputSourceType, Handedness>(InputSourceType.Controller, Handedness.Right) ,
            new Tuple<InputSourceType, Handedness>(InputSourceType.Controller, Handedness.Left) ,
        };

        void Update()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var tuple in inputSources)
            {
                var sourceType = tuple.Item1;
                var handedness = tuple.Item2;
                sb.Append(sourceType.ToString() + " ");
                if (handedness != Handedness.Any)
                {
                    sb.Append(handedness.ToString());
                }
                sb.Append(": ");
                Ray myRay;
                if (InputRayUtils.TryGetRay(sourceType, handedness, out myRay))
                {
                    sb.Append($"pos: ({myRay.origin.x:F2}, {myRay.origin.y:F2}, {myRay.origin.z:F2}");
                    sb.Append($" forward: ({myRay.direction.x:F2}, {myRay.direction.y:F2}, {myRay.direction.z:F2}");
                }
                else
                {
                    sb.Append(" not available");
                }
                sb.AppendLine();
            }
            var tmp = sb.ToString();
            Debug.Log(tmp);
            sb.Clear();
        }

        public void Start()
        {
            // Disable the hand and gaze ray, we don't want then for this demo and the conflict
            // with the visuals
            PointerUtils.SetGazePointerBehavior(PointerBehavior.AlwaysOff);
            PointerUtils.SetHandRayPointerBehavior(PointerBehavior.AlwaysOff);
        }

    }
}

