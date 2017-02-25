package models;

public class Vertex3D extends Vertex2D {
    private double z;

    public Vertex3D(double x, double y, double z) {
        super(x, y);
        this.setZ(z);
    }

    public double getZ() {
        return z;
    }

    private void setZ(double z) {
        this.z = z;
    }

    @Override
    public String toString() {
        StringBuilder vertexInfo = new StringBuilder();
        vertexInfo.append(String.format("(%.2f, %.2f, %.2f)", this.getX(), this.getY(), this.getZ()));
        return  vertexInfo.toString();
    }
}