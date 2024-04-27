// DAVIDE PRESTI
// - Ejercicio 3 -

// Vamos a diseñar las clases para un posible sistema operativo de una antigua radio de coche con DAB (Digital Audio 
// Broadcasting) y un reproductor de CD.

// Para ello, seguiremos el modelado propuesto en el diagrama de clases del ejemplo, teniendo en cuenta las 
// siguientes especificaciones funcionales.

// Tendremos una clase DABRadioCD que estará compuesta por dos dispositivos un reproductor de CD y un sintonizador DAB.
// En el reproductor de CD además podremos tener un Compat Disc® representado por la clase Disc.
// La clase Disc tendrá un indizador que permitirá acceder al título de cada canción y una sobreescritura de ToString que permitirá ver el nombre del álbum y el artista de la canción.

// Nota: Recuerda que en C# los Get (Accesores), Set (Mutadores) son Propiedades y que los campos se pueden implementar a través de Propiedades Autoimplementadas.

// El reproductor de CD implementa la interfaz IMedia con la funcionalidad:

// MessageToDisplay: Propiedad que devuelve un mensaje para el Display del DABRadioCD con el estado del reproductor. Devolviendo NO DISC si no hay un disco en su interior. Además, en este caso el resto de opciones de reproducción deberían devolver el mismo mensaje, no teniendo efecto.
// Play: Que reproducirá el disco desde la pista 1, si el reproductor está parado o desde la pista correspondiente si está pausado. Devolviendo en MessageToDisplay el estado, la información del CD y la pista que está sonando ...
// PLAYING... Album: Thriller Artist: Michael Jackson Track 1 - Wanna Be Startin' Somethin

// Stop: Parará la reproducción. Devolviendo MessageToDisplay...
// STOPPED... Album: Thriller Artist: Michael Jackson
// Pause: Pausará la reproducción si está sonando y la reanudará si está pausada. Si pasa a pausado, MessageToDisplay devolverá…
// PAUSED... Album: Thriller Artist: Michael Jackson. Track 1 - Wanna Be Startin' Somethin
// Next/Previous: Si esta sonando, buscará la anterior o siguiente pista a reproducir de forma cíclica. Esto es, si llega al final irá al principio y viceversa. Además, si está pausado empezará a reproducir la nueva pista.
// El sintonizador de DAB implementa el interfaz IMedia con la funcionalidad, empezará parada.

// MessageToDisplay: Propiedad que devuelve un mensaje para el Display del DABRadioCD con el estado de la radio.

// Play: Que sintonizará la primera frecuencia de la banda de FM (MIN_FREQUENCY) si estaba apagada (OFF) o continuará con el streaming almacenado en el buffer si estaba pausada. Devolviendo MessageToDisplay…
// HEARING... FM – 87,5 MHz

// Stop: Parará el streamig. Devolviendo MessageToDisplay… RADIO OFF

// Pause: Pausará la reproducción si está sonando la radio y la reanudará si está pausada. Si pasa a pausado se almacenará todo el streaming en un buffer para poder reanudar la emisión donde se quedó y MessageToDisplay devolverá…
// PAUSED - BUFFERING... FM – 87,5 MHz

// Next/Previous: Si esta sonando moverá el dial a la anterior o siguiente frecuencia, con saltos de 0,5 MHz cada vez que se pulse. Si llega al final de la banda (MAX_FREQUENCY) irá al principio de la misma y viceversa. Además, si está pausada empezará a reproducir desde la nueva frecuencia.

// Nuestro DABRadioCD implementa el interfaz IMedia con la funcionalidad:
// Para los métodos de IMedia, llamará a los respectivos del dispositivo activo en ese momento.

// MessageToDisplay: Devolverá una cadena con el dispositivo activo, el estado devuelto por el correspondiente método del dispositivo activo y el menú de opciones para manejar nuestro DABRadioCD.
// MODO: CD
// STATE: PLAYING... Album: Thriller Artist: Michael Jackson. Track 1 - Wanna Be Startin' Somethin
// [1]Play [2]Pause [3]Stop [4]Prev [5]Next [6]Switch [7]Insert CD [8]Extract CD, [ESC]Turn off
// Insertar un CD: Devolverá una excepción si ya hay un CD dentro del reproductor. Si no lo hay, pasaremos a modo CD y empezará la reproducción automáticamente.
// Extraer un CD: Retirará el CD del reproductor y pasará a modo DAB.
// Intercambiar modo: Pasará de CD a DAB o viceversa. Teniendo en cuenta que si pasamos a CD este empezará a reproducir donde se quedó.

namespace ejercicio3
{
    class CDPlayer : IMedia
    {
        private ushort Track {get; set;}
        private MediaState State {get; set;}
        public bool MediaIn 
        {
            get {return (Disc != default);}
        }
        private Disc Disc {get; set;}

        public CDPlayer()
        {
            Disc = default;
            State = MediaState.Stopped;
        }

        public void InsertMedia(Disc media)
        {
            Disc = media;
            State = MediaState.Stopped;
        }

        public bool ExtractMedia()
        {
            Disc = default;
            bool extractMedia = MediaIn;
            State = MediaState.Stopped;
            return extractMedia;
        }

        public string MessageToDisplay
        {
            get
            {
                string message;
                if (MediaIn)
                {
                    if (State == MediaState.Stopped)
                    {
                        message = $"STOPPED... {Disc}";
                    }
                    else if (State == MediaState.Paused)
                    {
                        message = $"PAUSED... {Disc}. Track {Track} - {Disc[Track - 1]}";
                    }
                    else if (State == MediaState.Playing)
                    {
                        message = $"PLAYING... {Disc}. Track {Track} - {Disc[Track - 1]}";
                    }
                    else
                    {
                        message = "ERROR!";
                    }
                }
                else
                {
                    message = "NO DISC";
                }    
                return message;
            }
        }

        public void Play()
        {
            if (State == MediaState.Stopped)
            {    
                Track = 1;
            }    
            State = MediaState.Playing;
        }

        public void Stop()
        {
            State = MediaState.Stopped;
        }        

        public void Pause()
        {
            switch (State)
            {
                case MediaState.Stopped:
                    break;
                case MediaState.Paused:
                    State = MediaState.Playing;
                    break;
                case MediaState.Playing:
                    State = MediaState.Paused;
                    break;
                default:
                    break;
            }
        }

        public void Next()
        {
            if (MediaIn && State != MediaState.Stopped)
            {
                if (MediaIn && Track == Disc.NumTracks)
                {
                    Track = 1;
                }
                else
                {
                    Track += 1;
                }
                Play();
            }
        }

        public void Previous()
        {
            if (MediaIn && State != MediaState.Stopped)
            {
                if (Track == 1)
                {
                    Track = (ushort) Disc.NumTracks;
                }
                else
                {
                    Track -= 1;
                }
                Play();
            }
        }
    }
}