using System;
using System.Collections.Generic;
using System.Globalization;

namespace FluentApi.Graph
{
    public enum NodeShape
    {
        Box,
        Ellipse
    }

    public interface IGraphBuilder
    {
        GraphNodeBuilder AddNode(string nodeName);
        GraphEdgeBuilder AddEdge(string sourceNode, string destinationNode);
        string Build();
    }

    public class DotGraphBuilder : IGraphBuilder
    {
        private readonly Graph Graph;

        private DotGraphBuilder(string graphName, bool directed)
        {
            Graph = new Graph(graphName, directed, false);
        }

        public GraphNodeBuilder AddNode(string nodeName)
        {
            return new GraphNodeBuilder(Graph.AddNode(nodeName), this);
        }

        public GraphEdgeBuilder AddEdge(string sourceNode, string destinationNode)
        {
            return new GraphEdgeBuilder(Graph.AddEdge(sourceNode, destinationNode), this);
        }

        public string Build() => Graph.ToDotFormat();

        public static IGraphBuilder DirectedGraph(string graphName)
        {
            return new DotGraphBuilder(graphName, true);
        }

        public static IGraphBuilder UndirectedGraph(string graphName)
        {
            return new DotGraphBuilder(graphName, false);
        }
    }

    public class GraphBuilder : IGraphBuilder
    {
        protected readonly IGraphBuilder Parent;

        public GraphBuilder(IGraphBuilder parent)
        {
            Parent = parent;
        }

        public GraphNodeBuilder AddNode(string nodeName)
        {
            return Parent.AddNode(nodeName);
        }

        public GraphEdgeBuilder AddEdge(string sourceNode, string destinationNode)
        {
            return Parent.AddEdge(sourceNode, destinationNode);
        }

        public string Build() => Parent.Build();
    }

    public class GraphEdgeBuilder : GraphBuilder
    {
        private readonly GraphEdge Edge;

        public GraphEdgeBuilder(GraphEdge edge, IGraphBuilder parent) : base(parent)
        {
            Edge = edge;
        }

        public IGraphBuilder With(Action<EdgeCommonAttributesConfig> applyAttributes)
        {
            applyAttributes(new EdgeCommonAttributesConfig(Edge));
            return Parent;
        }
    }

    public class GraphNodeBuilder : GraphBuilder
    {
        private readonly GraphNode Node;

        public GraphNodeBuilder(GraphNode node, IGraphBuilder parent) : base(parent)
        {
            Node = node;
        }

        public IGraphBuilder With(Action<NodeCommonAttributesConfig> applyAttributes)
        {
            applyAttributes(new NodeCommonAttributesConfig(Node));
            return Parent;
        }
    }

    public class CommonAttributesConfig<T>
        where T : CommonAttributesConfig<T>
    {
        protected readonly IDictionary<string, string> Attributes;

        public CommonAttributesConfig(IDictionary<string, string> attributes)
        {
            Attributes = attributes;
        }

        public CommonAttributesConfig<T> Label(string label)
        {
            Attributes["label"] = label;
            return (T) this;
        }

        public CommonAttributesConfig<T> FontSize(float sizeInPt)
        {
            Attributes["fontsize"] = sizeInPt.ToString(CultureInfo.InvariantCulture);
            return (T) this;
        }

        public CommonAttributesConfig<T> Color(string color)
        {
            Attributes["color"] = color;
            return (T) this;
        }

    }

    public class NodeCommonAttributesConfig : CommonAttributesConfig<NodeCommonAttributesConfig>
    {
        private readonly GraphNode Node;

        public NodeCommonAttributesConfig(GraphNode node) : base(node.Attributes) => Node = node;

        public NodeCommonAttributesConfig Shape(NodeShape shape)
        {
            Node.Attributes["shape"] = shape.ToString().ToLowerInvariant();
            return this;
        }
    }

    public class EdgeCommonAttributesConfig : CommonAttributesConfig<EdgeCommonAttributesConfig>
    {
        private readonly GraphEdge Edge;

        public EdgeCommonAttributesConfig(GraphEdge edge) : base(edge.Attributes) => Edge = edge;

        public EdgeCommonAttributesConfig Weight(double weight)
        {
            Edge.Attributes["weight"] = weight.ToString(CultureInfo.InvariantCulture);
            return this;
        }
    }
}