//Show UCLA CS class dependencies (not complete)

var nodes = [];

function addNodes() {
    $(".node").each(function (a, e) {
        var name = $(e).find(".name").html().trim();
        var father = $(e).find(".father").html().trim();
        var mother = $(e).find(".mother").html().trim();
        if (name && father && mother) {
            nodes.push({
                name: name,
                father: father,
                mother: mother
            });
        }
    });
}

function drawGraphSpring() {
    $("#canvasSping").empty();
    var width = 500;
    var height = 300;
    var g = new Graph();
    for (var i = 0; i < nodes.length; i++) {
        g.addEdge(nodes[i].name, nodes[i].father);
        g.addEdge(nodes[i].name, nodes[i].mother);
    }
    var layouter = new Graph.Layout.Spring(g);
    var renderer = new Graph.Renderer.Raphael('canvasSping', g, width, height);
}

function drawGraphOrdered() {
    $("#canvasOrdered").empty();
    var width = 500;
    var height = 300;
    var g = new Graph();
    for (var i = 0; i < nodes.length; i++) {
        g.addEdge(nodes[i].name, nodes[i].father);
        g.addEdge(nodes[i].name, nodes[i].mother);
    }
   // g.addEdge("petko", "stanko");
   // g.addEdge("petko", "marija");
   // g.addEdge("ana", "petko");
   // g.addEdge("ana", "petranka");
   // g.addEdge("petranka", "tose");
   // g.addEdge("petranka", "janka");
    var layouter = new Graph.Layout.Ordered(g, topological_sort(g));
    var renderer = new Graph.Renderer.Raphael('canvasOrdered', g, width, height);
};
