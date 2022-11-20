// React
import React, { useCallback, useRef } from "react";
// Reactflow
import ReactFlow, {
    MiniMap,
    Controls,
    Background,
    useNodesState,
    useEdgesState,
    addEdge,
    MarkerType,
    updateEdge,
    useStore,
    getBezierPath,
} from "reactflow";
// Utils
import { createNodesAndEdges, getEdgeParams } from "../utils";
// Styles
import "reactflow/dist/style.css";

const edgeTypes = {
    floating: FloatingEdge,
};

const { nodes: initialNodes, edges: initialEdges } = createNodesAndEdges();

function FloatingEdge({ id, source, target, markerEnd, style }) {
    const sourceNode = useStore(
        useCallback((store) => store.nodeInternals.get(source), [source])
    );
    const targetNode = useStore(
        useCallback((store) => store.nodeInternals.get(target), [target])
    );

    if (!sourceNode || !targetNode) {
        return null;
    }

    const { sx, sy, tx, ty, sourcePos, targetPos } = getEdgeParams(
        sourceNode,
        targetNode
    );

    const [edgePath] = getBezierPath({
        sourceX: sx,
        sourceY: sy,
        sourcePosition: sourcePos,
        targetPosition: targetPos,
        targetX: tx,
        targetY: ty,
    });

    return (
        <path
            id={id}
            className="react-flow__edge-path"
            d={edgePath}
            markerEnd={markerEnd}
            style={style}
        />
    );
}

function Flow() {
    const edgeUpdateSuccessful = useRef(true);
    const [nodes, , onNodesChange] = useNodesState(initialNodes);
    const [edges, setEdges, onEdgesChange] = useEdgesState(initialEdges);
    const onConnect = useCallback(
        (params) =>
            setEdges((eds) =>
                addEdge(
                    {
                        ...params,
                        type: "floating",
                        markerEnd: { type: MarkerType.Arrow },
                    },
                    eds
                )
            ),
        [setEdges]
    );

    const onEdgeUpdateStart = useCallback(() => {
        edgeUpdateSuccessful.current = false;
    }, []);

    const onEdgeUpdate = useCallback(
        (oldEdge, newConnection) => {
            edgeUpdateSuccessful.current = true;
            setEdges((els) => updateEdge(oldEdge, newConnection, els));
        },
        [setEdges]
    );

    const onEdgeUpdateEnd = useCallback(
        (_, edge) => {
            if (!edgeUpdateSuccessful.current) {
                setEdges((eds) => eds.filter((e) => e.id !== edge.id));
            }

            edgeUpdateSuccessful.current = true;
        },
        [setEdges]
    );

    return (
        <div className="Flow" style={{ height: "100%" }}>
            <ReactFlow
                edgeTypes={edgeTypes}
                nodes={nodes}
                edges={edges}
                onNodesChange={onNodesChange}
                onEdgesChange={onEdgesChange}
                snapToGrid
                onEdgeUpdate={onEdgeUpdate}
                onEdgeUpdateStart={onEdgeUpdateStart}
                onEdgeUpdateEnd={onEdgeUpdateEnd}
                onConnect={onConnect}
                fitView
                attributionPosition="top-right"
            >
                <MiniMap />
                <Controls />
                <Background />
            </ReactFlow>
        </div>
    );
}

export { FloatingEdge, Flow };
