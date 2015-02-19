package models.spaceShapes;

import models.SpaceShape;
import models.Vertex3D;

public class SquarePyramid extends SpaceShape {
    private double baseWidth;
    private double pyramidHeight;

    public SquarePyramid(Vertex3D baseCenter, double baseWidth, double pyramidHeight) {
        super(new Vertex3D[]{baseCenter});
        this.setBaseWidth(baseWidth);
        this.setPyramidHeight(pyramidHeight);
    }

    public double getBaseWidth() {
        return baseWidth;
    }

    private void setBaseWidth(double baseWidth) {
        if (baseWidth <= 0) {
            throw new IllegalArgumentException();
        }

        this.baseWidth = baseWidth;
    }

    public double getPyramidHeight() {
        return pyramidHeight;
    }

    private void setPyramidHeight(double pyramidHeight) {
        if (pyramidHeight <= 0) {
            throw new IllegalArgumentException();
        }

        this.pyramidHeight = pyramidHeight;
    }

    @Override
    public String getShapeName() {
        return "Square Pyramid";
    }

    @Override
    public double getArea() {
        double slantHeight = Math.sqrt(
                Math.pow((this.getBaseWidth() / 2), 2) +
                Math.pow(this.getPyramidHeight(), 2));
        double area =
                2 * this.getBaseWidth() * slantHeight +
                Math.pow(this.getBaseWidth(), 2);

        return area;
    }

    @Override
    public double getVolume() {
        double volume = (Math.pow(this.getBaseWidth(), 2) * this.getPyramidHeight()) / 3;
        return volume;
    }

    @Override
    public String toString() {
        StringBuilder squarePyramidInfo = new StringBuilder();
        squarePyramidInfo.append(String.format("%s\r\n", this.getShapeName()));
        squarePyramidInfo.append(String.format("base center point coordinates: %s\r\n", getVertices3D()[0]));
        squarePyramidInfo.append(String.format("base width = %.2f\r\n", this.getBaseWidth()));
        squarePyramidInfo.append(String.format("pyramid height = %.2f\r\n", this.getPyramidHeight()));
        squarePyramidInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        squarePyramidInfo.append(String.format("volume = %.2f", this.getVolume()));

        return squarePyramidInfo.toString();
    }

}