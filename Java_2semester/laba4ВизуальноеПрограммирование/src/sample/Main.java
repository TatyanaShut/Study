package sample;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Group;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Slider;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.scene.shape.Rectangle;
import javafx.scene.shape.StrokeLineCap;
import javafx.scene.text.Text;
import javafx.stage.Stage;
import javafx.scene.shape.Line;



public class Main extends Application {



    @Override
    public void start(Stage primaryStage) throws Exception{


        primaryStage.setTitle("Work with g");

        Group root = new Group ();

        Scene scene = new Scene(root,300, 300, Color.GRAY);

        Line redLine = new Line(10,10,300,10);
        redLine.setStroke(Color.RED);
        redLine.setStrokeWidth(10);
        redLine.setStrokeLineCap(StrokeLineCap.BUTT);

        redLine.getStrokeDashArray().addAll(10d,5d,15d,5d,20d);
        redLine.setStrokeDashOffset(0);

        Line whiteLine = new Line (10,30,200,30);
        whiteLine.setStroke(Color.WHITE);
        whiteLine.setStrokeWidth(10);
        whiteLine.setStrokeLineCap(StrokeLineCap.ROUND);


        Line blueLine = new Line(10,50,200,50);
        blueLine.setStroke(Color.BLUE);
        blueLine.setStrokeWidth(10);

        Slider slider = new Slider(0,100,0);
        slider.setLayoutX(10);
        slider.setLayoutY(95);

        redLine.strokeDashOffsetProperty().bind(slider.valueProperty());

        Text offsetText = new Text ("Позиция линии:" + slider.getValue());
        offsetText.setX(10);
        offsetText.setY(80);
        offsetText.setStroke(Color.WHITE);

        slider.valueProperty().addListener((ov, curVal, newVal )-> offsetText.setText("Позиция:" + newVal));







        VBox layout = new VBox(10);
        layout.setMinHeight(scene.getHeight());

        Button openCircle = new Button ("Открыть круг");
        openCircle.setOnAction(e -> CircleBox.display());

        Button openRectangle = new Button("Открыть прямоугольник");
        openRectangle.setOnAction(e-> RactangleBox.display());

        Button openIceCream = new Button("Открыть мороженное");
        openIceCream.setOnAction(e-> IceCreamBox.display());





//        root.getChildren().add(redLine);
//        root.getChildren().add(whiteLine);
//        root.getChildren().add(blueLine);
//        root.getChildren().add(slider);
//        root.getChildren().add(offsetText);
//        root.getChildren().add(layout);
//        root.getChildren().add(openCircle);
//        root.getChildren().add(openRectangle);
       root.getChildren().add(openIceCream);

        primaryStage.setScene(scene);


        primaryStage.show();


    }


    public static void main(String[] args) {
        launch(args);
    }
}
