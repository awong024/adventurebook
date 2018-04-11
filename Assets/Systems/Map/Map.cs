using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {
    public class NodeRow {
        private List<MapNode> nodes = new List<MapNode>();

        private const int EXTRA_NODE_EXIT_CHANCE = 50;

        public NodeRow(int row_number, int numNodes) {
            for (int i = 0; i < numNodes; i++) {
                MapNode node = new MapNode(i, row_number);
                node.Init();
                nodes.Add(node);
            }
        }

        public List<MapNode> Nodes { get { return nodes; } }

        public void GenerateNodeConnections(NodeRow nextRow) {
            //[Mandatory Links]
            //Top to Top
            nodes[0].AddExitLink(0);

            //Bottom to Bottom
            nodes[nodes.Count - 1].AddExitLink(nextRow.Nodes.Count - 1);

            if (nodes.Count == 3) {
                //3:2 middle requires exit
                if (nextRow.Nodes.Count == 2) {
                    int chosen_exit = UnityEngine.Random.Range(0, 2);
                    nodes[1].AddExitLink(chosen_exit);
                }
                //3:3 middle requires exit
                else if (nextRow.Nodes.Count == 3) {
                    int chosen_exit = UnityEngine.Random.Range(0, 3);
                    nodes[1].AddExitLink(chosen_exit);

                    //3:3 middle requires path (but no crossing)
                    if (chosen_exit == 0) {
                        nodes[2].AddExitLink(1);
                    } else if (chosen_exit == 2) {
                        nodes[0].AddExitLink(1);
                    }
                }
            }
            else if (nodes.Count == 2) {
                //2:3 middle requires path
                if (nextRow.Nodes.Count == 3) {
                    int chosen_node = UnityEngine.Random.Range(0, 2);
                    nodes[chosen_node].AddExitLink(1);
                }
            }

            //[Optional Links]
            if (nodes.Count == 2) {
                //2:2 Chance for one path
                if (nextRow.Nodes.Count == 2) {
                    if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                        int chosen_node = UnityEngine.Random.Range(0, 2);
                        nodes[chosen_node].AddExitLink(UnityEngine.Random.Range(0, 2));
                    }
                } 
                //2:3 Chance for one/two path
                else if (nextRow.Nodes.Count == 3) {
                    for (int i = 0; i < 2; i++) {
                        if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                            nodes[i].AddExitLink(1);
                        }   
                    }
                }
            } else if (nodes.Count == 3) {
                if (nextRow.Nodes.Count == 2) {
                    //3:2 Chance for second path from middle
                    if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                        if (nodes[1].ExitLinks.Count == 1) {
                            nodes[1].AddExitLink(nodes[1].ExitLinks[0] == 0 ? 1 : 0);
                        }
                    }
                } else if (nextRow.Nodes.Count == 3) {
                    //3:3 Chance for extra paths from each node (no crossing)
                    List<int> drawOrder = new List<int> { 0, 1, 2 };
                    while (drawOrder.Count > 0) {
                        int randomDraw = UnityEngine.Random.Range(0, drawOrder.Count);
                        if (drawOrder[randomDraw] == 0) {
                            DrawOptionalFromTop();
                        } else if (drawOrder[randomDraw] == 1) {
                            DrawOptionalFromMiddle();
                        } else if (drawOrder[randomDraw] == 2) {
                            DrawOptionalFromBottom();
                        }
                        drawOrder.Remove(drawOrder[randomDraw]);
                    }
                }
            }
        }

        private void DrawOptionalFromTop() {
            //Top node
            if (!nodes[1].HasExitLinkTo(0) && !nodes[0].HasExitLinkTo(1)) {
                if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                    nodes[0].AddExitLink(1);
                }
            }
        }

        private void DrawOptionalFromMiddle() {
            //Middle node
            if (!nodes[0].HasExitLinkTo(1) && !nodes[1].HasExitLinkTo(0)) {
                if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                    nodes[0].AddExitLink(1);
                }
            }
            if (!nodes[1].HasExitLinkTo(1)) {
                if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                    nodes[1].AddExitLink(1);
                }
            }
            if (!nodes[2].HasExitLinkTo(1) && !nodes[1].HasExitLinkTo(2)) {
                if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                    nodes[1].AddExitLink(2);
                }
            }
        }

        private void DrawOptionalFromBottom() {
            //Bottom node
            if (!nodes[1].HasExitLinkTo(2) && !nodes[2].HasExitLinkTo(1)) {
                if (UnityEngine.Random.Range(0, 100) < EXTRA_NODE_EXIT_CHANCE) {
                    nodes[2].AddExitLink(1);
                }
            }
        }
    }

    List<NodeRow> nodeRows = new List<NodeRow>();

    private const int NUM_NODE_ROWS = 6;
    private const int MIN_NODES_PER_ROW = 2; //Hardcoded
    private const int MAX_NODES_PER_ROW = 3; //Hardcoded

    //Accessors
    public List<NodeRow> NodeRows { get { return nodeRows; } }

    public void GenerateNodeMap() {
        nodeRows.Clear();

        for (int i = 0; i < NUM_NODE_ROWS; i++) {
            int numOfNodes = UnityEngine.Random.Range(MIN_NODES_PER_ROW, MAX_NODES_PER_ROW + 1);
            NodeRow newRow = new NodeRow(i, numOfNodes);
            nodeRows.Add(newRow);
        }
        GenerateNodeNetwork();
    }

    private void GenerateNodeNetwork() {
        for (int i = 0; i < nodeRows.Count - 1; i++) {
            NodeRow nextRow = nodeRows[i + 1];
            nodeRows[i].GenerateNodeConnections(nextRow);
        }
    }
}
