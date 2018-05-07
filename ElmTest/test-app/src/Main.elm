module Main exposing (..)

import Html exposing (Html, button, div, h1, img, input, text)
import Html.Attributes exposing (src, value)
import Html.Events exposing (onClick, onInput)


---- MODEL ----


type alias Model =
    { counter : Int
    , name : String
    }


init : ( Model, Cmd Msg )
init =
    ( Model 0 "", Cmd.none )



---- UPDATE ----


type Msg
    = Incremenet
    | Decrement
    | Reset
    | Name String


update : Msg -> Model -> ( Model, Cmd Msg )
update msg model =
    let
        counter =
            model.counter
    in
    case msg of
        Incremenet ->
            ( { model | counter = counter + 1 }, Cmd.none )

        Decrement ->
            ( { model | counter = counter - 1 }, Cmd.none )

        Reset ->
            ( { model | counter = 0, name = "" }, Cmd.none )

        Name n ->
            ( { model | name = n }, Cmd.none )



---- VIEW ----


view : Model -> Html Msg
view model =
    div []
        [ img [ src "/logo.svg" ] []
        , h1 [] [ text "Your Elm App is working!" ]
        , div []
            [ h1 [] [ text "lets try some stuff eh" ]
            , h1 [] [ text "ahhh this is where this goes" ]
            , h1 [] [ text "how do i put render stuff" ]
            , button [ onClick Incremenet ] [ text "+" ]
            , div [] [ text (toString model.counter) ]
            , button [ onClick Decrement ] [ text "-" ]
            , button [ onClick Reset ] [ text "reset" ]
            , input [ onInput Name, value model.name ] []
            ]
        ]



---- PROGRAM ----


main : Program Never Model Msg
main =
    Html.program
        { view = view
        , init = init
        , update = update
        , subscriptions = always Sub.none
        }
