using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replaces letters with underscores, preserving punctuation
            char[] hiddenChars = new char[_text.Length];
            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsLetterOrDigit(_text[i]))
                {
                    hiddenChars[i] = '_';
                }
                else
                {
                    hiddenChars[i] = _text[i];
                }
            }
            return new string(hiddenChars);
        }

        return _text;
    }
}