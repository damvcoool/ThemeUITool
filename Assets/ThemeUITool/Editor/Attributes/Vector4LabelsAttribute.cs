using UnityEngine;

namespace ThemedUITool
{
    public class Vector4LabelsAttribute : PropertyAttribute
    {
        public string xLabel;
        public string yLabel;
        public string zLabel;
        public string wLabel;

        public Vector4LabelsAttribute(string xLabel, string yLabel, string zLabel, string wLabel)
        {
            this.xLabel = xLabel;
            this.yLabel = yLabel;
            this.zLabel = zLabel;
            this.wLabel = wLabel;
        }
    }
}