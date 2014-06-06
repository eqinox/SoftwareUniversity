import greenfoot.*;  // (World, Actor, GreenfootImage, Greenfoot and MouseInfo)

/**
 * Write a description of class FlappyWorld here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class FlappyWorld extends World
{
    int pipeCounter = 0;
    int flappyCounter = 0;
    int pipeSpace = 150;
    public static int score = 0;
    int firstPipe = 240;
    Score scoreObj = null;
    /**
     * Constructor for objects of class FlappyWorld.
     * 
     */
    public FlappyWorld()
    {    
        // Create a new world with 600x400 cells with a cell size of 1x1 pixels.
        super(600, 400, 1,false);
        setPaintOrder(Score.class, GameOver.class, Pipe.class, FlappyBird.class);
        FlappyBird flappy = new FlappyBird();
        addObject(flappy,100,200);
        scoreObj = new Score();
        
        scoreObj.setScore(0);
        addObject(scoreObj,getWidth()/2,0 + 25);
        
    }
    
    public void act() {
        pipeCounter++;
        if (pipeCounter % 100 == 0) {
            //Pipe pippy = new Pipe();
            //GreenfootImage image = pippy.getImage();
            //addObject(pippy,getWidth(),getHeight()/2 + image.getHeight() - random);
            createPipes();
        }
        if(pipeCounter >= firstPipe){
            if(flappyCounter % 100 == 0){
                score++;
                scoreObj.setScore(score);
            }
            flappyCounter++;
        }
    }
    
    private void createPipes(){
        int random = Greenfoot.getRandomNumber(150);
        Pipe topPipe = new Pipe();
        Pipe botPipe = new Pipe();
        GreenfootImage imageTop = topPipe.getImage();
        GreenfootImage imageBot = botPipe.getImage();
        int newRandom = random;
        addObject(botPipe, getWidth(), getHeight()/2 + imageBot.getHeight() + 50 - newRandom);
        addObject(topPipe, getWidth(), getHeight()/2 - newRandom - pipeSpace);
    }
    
    private void createPower(){
        Power cherry = new Power();
        addObject(cherry, getWidth(), getHeight()/2);
    }
}
