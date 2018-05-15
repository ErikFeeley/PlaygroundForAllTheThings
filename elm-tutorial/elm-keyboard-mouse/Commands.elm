module Commands exposing (..)

import Html exposing (Html, div, button, text, program)
import Html.Events exposing (onClick)
import Random


-- MODEL


type alias Model =
    { randomNum : Int
    , randomBool : Bool
    }


init : ( Model, Cmd Msg )
init =
    ( Model 1 False, Cmd.none )



-- MESSAGES


type Msg
    = Roll
    | OnResult Int
    | GenerateBool
    | OnBoolResult Bool



-- VIEW


view : Model -> Html Msg
view model =
    div []
        [ randomStuff (toString model.randomNum) Roll
        , randomStuff (toString model.randomBool) GenerateBool
        ]



-- sick refactor bro


randomStuff : String -> Msg -> Html Msg
randomStuff randomThingy msg =
    div []
        [ button [ onClick msg ] [ text "generate" ]
        , text randomThingy
        ]



-- UPDATE


update : Msg -> Model -> ( Model, Cmd Msg )
update msg model =
    case msg of
        Roll ->
            -- Random.generate infers the type from the type constructor in this case OnResult for Int
            ( model, Random.generate OnResult (Random.int 1 6) )

        OnResult res ->
            ( { model | randomNum = res }, Cmd.none )

        GenerateBool ->
            -- cool bool result was inferred.
            ( model, Random.generate OnBoolResult Random.bool )

        OnBoolResult res ->
            ( { model | randomBool = res }, Cmd.none )



-- MAIN


main : Program Never Model Msg
main =
    Html.program
        { init = init
        , view = view
        , update = update
        , subscriptions = (always Sub.none) -- handy
        }
