using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellDetectionVisualizer : MonoBehaviour {

    public GameObject point;
    public RectTransform detectionArea;
    private RectTransform canvas;
    public int spell_id;
    public bool has_drawing_pad = true;

    private bool hasGenerated;
    private List<SpellDetectionPoint> points;
    private SpellDetectionPattern detectionPattern;

    private int fadeOverNextPoints = 10;
    private static float fade = 0.2f;
    private Color colorWaiting = new Color(0, 0, 1, fade);
    private Color colorSelected = new Color(0, 1, 0, fade);
    private Color colorInvalid = new Color(0, 0, 0, 0);

    // Use this for initialization
    void Start () {
        hasGenerated = false;
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
		if (!hasGenerated && Spell.SPELLS[spell_id].detectionPattern != null)
        {
            hasGenerated = true;
            detectionPattern = Spell.SPELLS[spell_id].detectionPattern;
            points = detectionPattern.GetPoints();

            for (int i = 0; i < points.Count; i++)
            {
                GameObject gameObject = Instantiate(point, transform);
                RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

                Vector3 pos = rectTransform.localPosition;
                pos.x += detectionArea.rect.width * (points[i].x - 0.5f);
                pos.y += detectionArea.rect.height * (points[i].y - 0.5f);

                rectTransform.localPosition = pos;
                rectTransform.sizeDelta = new Vector2(detectionPattern.GetRadius() * detectionArea.rect.width * 2, detectionPattern.GetRadius() * detectionArea.rect.height * 2);

                points[i].gameObject = gameObject;
            }
        }
        else if (hasGenerated && detectionPattern.IsDirty())
        {
            detectionPattern.SetDirty(false);
            for (int i = 0; i < points.Count; i++)
            {
                SpellDetectionPoint point = points[i];
                Image image = point.gameObject.GetComponent<Image>();
                Color color = colorSelected;

                /*int fadeVal = fadeOverNextPoints;
                if (detectionPattern.NextPoint() == 0) fadeVal = 3;

                float a = color.a * (((float) (detectionPattern.NextPoint() + fadeVal) - i) / fadeVal);
                //Debug.Log(detectionPattern.NextPoint());
                if (i <= detectionPattern.NextPoint()) a = color.a;
                if (a < 0) a = 0;
                if (i > detectionPattern.NextPoint() + fadeOverNextPoints) a = 0;

                color.a = a;*/
                image.color = color;
            }
        }
	}
}
