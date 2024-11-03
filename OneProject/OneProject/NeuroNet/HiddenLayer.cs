using System.Diagnostics.Tracing;

namespace OneProject.NeuroNet
{
    class HiddenLayer: Layer
    {
        public HiddenLayer(int non,int nopn,NeuronType nt,string type):
            base(non, nopn, nt, type) { }
        public override void Recognize(NetWork net, Layer nextlayer)
        {
            double[] hidden_out = new double[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++)
            {
                hidden_out[i] = Neurons[i].Output;
            }
            nextlayer.Data=hidden_out;
        }
        public override double[] BackwardPass(double[] gr_sums)
        {
            //Код обучения нейронки
            double[] gr_sum=new double[numofprevneurons];
            return gr_sum;
        }
    }
}
