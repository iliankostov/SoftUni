package models.spaceShapes;

import models.SpaceShape;
import models.Vertex3D;

public class Sphere extends SpaceShape {
    private double radius;

    public Sphere(Vertex3D center, double radius) {
        super(new Vertex3D[]{center});
        this.setRadius((radius));
    }

    public double getRadius() {
        return radius;
    }

    private void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException();
        }

        this.radius = radius;
    }

    @Override
    public String getShapeName() {
        return "Sphere";
    }

    @Override
    public double getArea() {

        double area = 4 * Math.PI * this.getRadius() * this.getRadius();
        return area;
    }

    @Override
    public double getVolume() {
        double volume = 4 * Math.PI * Math.pow(this.getRadius(), 3) / 3;
        return volume;
    }

    @Override
    public String toString() {
        StringBuilder sphereInfo = new StringBuilder();
        sphereInfo.append(String.format("%s\r\n", this.getShapeName()));
        sphereInfo.append(String.format("radius = %.2f\r\n", this.getRadius()));
        sphereInfo.append(String.format("center point coordinates: %s\r\n", getVertices3D()[0]));
        sphereInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        sphereInfo.append(String.format("volume = %.2f", this.getVolume()));

        return sphereInfo.toString();
    }
}