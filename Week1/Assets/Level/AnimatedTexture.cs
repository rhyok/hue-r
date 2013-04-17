using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour {
    public int rows;
    public int columns;
    public int currentRow;
    public int currentColumn;
    public int framerate;
    public int startAtFrame;
    
    public bool loop;
    ////public bool loopOnRange;
    //public int loopStartRow;
    //public int loopStartColumn;
    //public int loopEndRow;
    //public int loopEndColumn;

    private int frameCounter;
    private int maxFrame;
    public Vector2 tilingDimensions = new Vector2(1f, 1f);

    void Start()
    {
        frameCounter = 0;
        currentRow = 0;
        currentColumn = 0;
        maxFrame = rows * columns;
        setTexturePosition();
    }
    void Update()
    {
        if (frameCounter >= framerate)
        {
            currentColumn++;
            if (currentColumn >= columns)
            {
                currentColumn = 0;
                if (currentRow + 1 >= rows)
                {
                    if(loop)
                        currentRow = 0;
                    else
                    {
                        currentColumn = columns;
                        currentRow = rows;
                    }
                }
            }
            setTexturePosition();
            frameCounter = 0;
        }
        frameCounter++;
    }
    void setTexturePosition()
    {
        Vector2 sheetPos;
        sheetPos.x = ((float) currentRow)/((float) rows);
        sheetPos.y = ((float) currentColumn)/((float)columns);

        renderer.material.SetTextureOffset("_MainTex", sheetPos);
        //renderer.material.SetTextureScale("_MainTex", tilingDimensions);
    }
}
