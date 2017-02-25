package models;

public abstract class Shape {
    private Vertex2D[] vertices2D;
    private Vertex3D[] vertices3D;

    protected Shape(Vertex2D[] vertices2D) {
        this.setVertices2D(vertices2D);
    }

    protected Shape(Vertex3D[] vertices3D) {
        this.setVertices3D(vertices3D);
    }

    public Vertex2D[] getVertices2D() {
        return vertices2D;
    }

    private void setVertices2D(Vertex2D[] vertices2D) {
        if (vertices2D == null || vertices2D.length == 0) {
            throw new NullPointerException();
        }

        this.vertices2D = vertices2D;
    }

    public Vertex3D[] getVertices3D() {
        return vertices3D;
    }

    private void setVertices3D(Vertex3D[] vertices3D) {
        if (vertices3D == null || vertices3D.length == 0) {
            throw new NullPointerException();
        }

        this.vertices3D = vertices3D;
    }

    public abstract String getShapeName();
}