package models.spaceShapes;

import models.SpaceShape;
import models.Vertex3D;

public class Cuboid extends SpaceShape {
    private double width;
    private double height;
    private double depth;

    public Cuboid(Vertex3D a, double width, double height, double depth) {
        super(new Vertex3D[]{a});
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    public double getWidth() {
        return width;
    }

    private void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException();
        }

        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    private void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException();
        }

        this.height = height;
    }

    public double getDepth() {
        return depth;
    }

    private void setDepth(double depth) {
        if (depth <= 0) {
            throw new IllegalArgumentException();
        }

        this.depth = depth;
    }

    @Override
    public String getShapeName() {
        return "Cuboid";
    }

    @Override
    public double getArea() {
        double area =
                2 * (this.getWidth() * this.getHeight()) +
                2 * (this.getWidth() * this.getDepth()) +
                2 * (this.getDepth() * this.getHeight());

        return area;
    }

    @Override
    public double getVolume() {
        double volume = this.getWidth() * this.getHeight() * this.getDepth();
        return volume;
    }

    @Override
    public String toString() {
        StringBuilder cuboidInfo = new StringBuilder();
        cuboidInfo.append(String.format("%s\r\n", this.getShapeName()));
        cuboidInfo.append(String.format("base center point coordinates: %s\r\n", getVertices3D()[0]));
        cuboidInfo.append(String.format("width = %.2f\r\n", this.getWidth()));
        cuboidInfo.append(String.format("height = %.2f\r\n", this.getHeight()));
        cuboidInfo.append(String.format("depth = %.2f\r\n", this.getDepth()));
        cuboidInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        cuboidInfo.append(String.format("volume = %.2f", this.getVolume()));

        return cuboidInfo.toString();
    }
}