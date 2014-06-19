import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.File;
import java.awt.Color;

/**
 * Write a description of class FlappyBird here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class FlappyBird extends Actor
{
    double dy = 0;
    double g = 0.2;
    int boostSpeed = -5;
    int X = 0;
    /**
     * Act - do whatever the FlappyBird wants to do. This method is called whenever
     * the 'Act' or 'Run' button gets pressed in the environment.
     */
    public void act() 
    {
        if (getOneIntersectingObject(Pipe.class) != null) {
            displayGameOver();
        }
        movement();
        setRotation();
        if(getY() > getWorld().getHeight()) {
            displayGameOver();
        }
        dy = dy + g;
    } 
    
    private void displayGameOver() {
        GameOver gameOver = new GameOver();
            getWorld().addObject(gameOver, getWorld().getWidth()/2, getWorld().getHeight()/2);
            int score = 0;
            try{
                if (new File("BestScore.txt").exists()) {
				BufferedReader reader = new BufferedReader(new FileReader("BestScore.txt"));
                score = Integer.parseInt(reader.readLine());
                reader.close();
				if(FlappyWorld.score > score){
				score = FlappyWorld.score;
                BufferedWriter writer = new BufferedWriter(new FileWriter("BestScore.txt"));
                writer.write("" + FlappyWorld.score);
                writer.close();
            }}
            else{
                BufferedWriter writer = new BufferedWriter(new FileWriter("BestScore.txt"));
                writer.write("" + FlappyWorld.score);
                score = FlappyWorld.score;
                writer.close();
            }
        } catch(IOException e){
            e.printStackTrace();
        }
            if(score != 0){
                Score image = new Score();
                image.setImage(new GreenfootImage("Best Score:" + score, 60, Color.WHITE, new Color(50,50,50,125)));
                
                this.getWorld().addObject(image, this.getWorld().getWidth() / 2, this.getWorld().getHeight() / 2 - new GameOver().getImage().getHeight() / 2 - 30);
            }
            else{
                Score image = new Score();
                image.setImage(new GreenfootImage("Best Score:" + FlappyWorld.score, 60, Color.WHITE, new Color(50,50,50,125)));
                this.getWorld().addObject(image, this.getWorld().getWidth() / 2, this.getWorld().getHeight() / 2 - new GameOver().getImage().getHeight() / 2 - 30);
            }
            FlappyWorld.score = 0;
            Greenfoot.stop();
    }
    
    private void movement(){
        setLocation(getX(),(int)(getY()+dy));
        if(Greenfoot.isKeyDown("up") == true) {
            dy = boostSpeed;
        }
        if(Greenfoot.isKeyDown("right") == true){
            setLocation(getX()+3,getY());
        }
        else if (Greenfoot.isKeyDown("left") == true){
            setLocation(getX()-2,getY());
        }
    }
    
    private void setRotation(){
        if( dy > -8 && dy < 5 ){
            setRotation(-6);
        }
        else if( dy >= 5 && dy < 9 ){
            setRotation(6);
        }
        else if( dy >= 9 ){
            setRotation(12);
        }
    }
}
