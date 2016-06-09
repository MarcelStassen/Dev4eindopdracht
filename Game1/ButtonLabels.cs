﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
  interface IComponent
  {
    void Update(float dt);
    void Draw(SpriteBatch spriteBatch);
  }
  abstract class IElement: IGui, IComponent
  {
    public abstract void Visit(IGuiVisitor visitor); 
    public abstract void Update(float dt);
    public abstract void Draw(SpriteBatch spriteBatch); 
   
  }
 
  class Button : IElement
  {
    private string Name;
    private Texture2D rectangle;
    private Rectangle buttonshape;
    private Color iColor;
    private Color bColor;
    private Color hColor;
    private SpriteFont font;
    private Label label;
    private Vector2 fontpos;
    private Vector2 textsize;
    private MouseState mouse;


    public Button(string Name, Texture2D  rectangle, Rectangle buttonshape, Color iColor, Color hColor, SpriteFont font)
    {
      this.Name = Name;
      this.rectangle = rectangle;
      this.iColor = iColor;
      this.hColor = hColor;
      this.buttonshape = buttonshape;
      this.bColor = iColor;
      this.font = font;
      // font mid calulation
      this.textsize = font.MeasureString(Name);
      this.fontpos = new Vector2((int)((buttonshape.X + buttonshape.Width / 2) -(textsize.X / 2)),(int)((buttonshape.Y + buttonshape.Height / 2) -(textsize.Y / 2)));
     
      this.label = new Label(Name, fontpos ,hColor,font);
    }

   
    public  override void Update(float dt)
    {     }

    public override void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(rectangle, buttonshape , bColor);
      label.Draw(spriteBatch);
    }
    
    public override void Visit(IGuiVisitor visitor)
    {
      
      this.mouse = mouse;
      visitor.onMyButton(this, mouse, buttonshape ,Name);
    }
  }
  class Label : IElement
  {
    private Color iColor;
    private string text;
    private SpriteFont font;
    private Vector2 position;
    
    public Label(string text, Vector2 position, Color iColor, SpriteFont font)
    {
      this.iColor = iColor;
      this.text = text;
      this.font = font;
      this.position = position;
    }

    public override void Update(float dt)
    {
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString(font, text, position, iColor);
    }

    public override void Visit(IGuiVisitor visitor)
    {
      visitor.onMyLabel(this);  
    }

  }
}