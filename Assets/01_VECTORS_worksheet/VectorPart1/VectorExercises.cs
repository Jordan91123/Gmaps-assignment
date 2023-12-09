using Unity.VisualScripting;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY,minZ,maxZ;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(3, 4);

        drawnLine = lineFactory.GetLine(startPt,endPt,0.02f,Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 =endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    void Question2b(int n)
    {
        float maxX = 5f;
        float maxY = 5f;
        for (int i = 0; i < lineFactory.maxLines; i++)
        {
            startPt = new Vector2(Random.Range(-maxX,maxX), Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            
            Vector2 vec2 = endPt - startPt;

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

            drawnLine.EnableDrawing(true);
            Debug.Log("Magnitude = " + vec2.magnitude);
        }
    }

    

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0,0,0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        float maxX = 5f;
        float maxY = 5f;
        float maxZ = 5f;
        for (int i = 0; i < n; i++)
        {
            Vector3 endPt = new Vector3(Random.Range(-maxX, maxX),Random.Range(-maxY, maxY), Random.Range(-maxZ, maxZ));
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                endPt,
                Color.white,
                60f); ;
        }
    }

    public void Question3a()
    {
        //formula for each variable
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = new HVector2D(a.x + b.x, a.y + b.y);
        HVector2D minus = new HVector2D(a.x - b.x, a.y - b.y);
        HVector2D negativeb = new HVector2D(-b.x, -b.y);

        //draws the arrows startpoint,vector,colour
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(a), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(b), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(c), Color.white, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(a), negativeb.ToUnityVector3(negativeb), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, minus.ToUnityVector3(minus), Color.white, 60f);

        //shows the magnitude of the arrows
        float magnitudeA = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        Debug.Log("Magnitude of a = " + magnitudeA.ToString("F2"));
        float magnitudeB = Mathf.Sqrt(b.x * b.x + b.y * b.y);
        Debug.Log("Magnitude of a = " + magnitudeB.ToString("F2"));
        float magnitudeC = Mathf.Sqrt(c.x * c.x + c.y * c.y);
        Debug.Log("Magnitude of a = " + magnitudeC.ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D halfa = new HVector2D(a.x / 2, a.y / 2);
        HVector2D b = new HVector2D(a.x*2,a.y*2);
        HVector2D newset = new HVector2D(1,0);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(a), Color.red, 60f);
        DebugExtension.DebugArrow(newset.ToUnityVector3(newset), halfa.ToUnityVector3(halfa), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D newset = new HVector2D(-1, 0);

        //finding magnitude to make it 1  
        float magnitude = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        HVector2D normalized = new HVector2D(a.x / magnitude, a.y / magnitude); 

        DebugExtension.DebugArrow(Vector3.zero, normalized.ToUnityVector3(normalized), Color.green, 60f);
        DebugExtension.DebugArrow(newset.ToUnityVector3(newset), a.ToUnityVector3(a), Color.red, 60f);
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);
        HVector2D v1 = new HVector2D(b.x - a.x,b.y - a.y);
        HVector2D v2 = new HVector2D(c.x - a.x,c.y - a.y);
        
        //finding projection 
        float dotProduct = v2.x * v1.x + v2.y * v1.y;
        float v1magsquare = v1.x * v1.x + v1.y * v1.y;
        HVector2D proj = new HVector2D((dotProduct / v1magsquare) * v1.x, (dotProduct / v1magsquare) * v1.y);

        DebugExtension.DebugArrow(a.ToUnityVector3(a), v1.ToUnityVector3(v1), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(a), v2.ToUnityVector3(v2), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(a), proj.ToUnityVector3(proj), Color.white, 60f);
    }
}
