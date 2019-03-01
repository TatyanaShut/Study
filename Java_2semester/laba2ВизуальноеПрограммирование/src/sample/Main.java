package sample;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.geometry.Pos;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.StackPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class Main extends Application {
    private Button button;
    private Button button2;


    @Override
    public void start(Stage primaryStage) throws Exception{
        Parent root = FXMLLoader.load(getClass().getResource("sample.fxml"));
        primaryStage.setTitle("alerts and interactions");

       button = new Button("Open modal window");
       button2 = new Button("Confirmation");
        ChoiceBox cb = new ChoiceBox();
        cb.getItems().addAll("Dog", "Cat", "Horse");
        cb.getSelectionModel().selectFirst();
       //return cb;


        button.setOnAction(e -> AlertBox.display("Modal window's title",""));
        button2.setOnAction(e -> AlertBox.display("Modal window's title","You are confirm"));


        BorderPane layout = new BorderPane();

        layout.setLeft(button);
        layout.setRight(button2);
        layout.setRight(cb);

        Scene scene = new Scene(layout, 300, 250);


        primaryStage.setScene(scene);
        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
