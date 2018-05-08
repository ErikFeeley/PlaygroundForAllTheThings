module Main exposing (..)


type alias Model =
    { counter : Int }


view : Model -> Html Msg
view model =
    div [] [ text "Hi" ]
