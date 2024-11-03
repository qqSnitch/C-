using System;

namespace OneProject.NeuroNet
{
    class NetWork
    {
        //Создание слоев
        private InputLayer input_layer = null;
        private HiddenLayer hidden_layer1 = new HiddenLayer(70,15,NeuronType.Hidden,nameof(hidden_layer1));
        private HiddenLayer hidden_layer2 = new HiddenLayer(35, 70, NeuronType.Hidden, nameof(hidden_layer2));
        private OutputLayer output_layer = new OutputLayer(10, 35, NeuronType.Output, nameof(output_layer));

        public double[] fact = new double[10];

        private double e_error_avr;
        public double E_error_avr { get => e_error_avr;set=>e_error_avr = value; }
        public NetWork() { }

        public void ForwardPass(NetWork net, double[] netInput)
        {
            net.hidden_layer1.Data = netInput;
            net.hidden_layer1.Recognize(null, net.hidden_layer2);
            net.hidden_layer2.Recognize(null, net.output_layer);
            net.output_layer.Recognize(net, null);
        }
    }
}

