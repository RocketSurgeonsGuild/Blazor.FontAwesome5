using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Regular Icons
/// </summary>
public static partial class FaRegular
{
    private static Icon? f_AddressBook;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-book?f=classic&amp;s=regular">Address Book</a>
    /// </summary>
    public static Icon AddressBook => f_AddressBook ??= new Icon(IconFamily.Classic, IconStyle.Regular, "address-book", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-book?f=classic&amp;s=regular">Address Book</a>
    /// </summary>
    public static Icon ContactBook => global::Someplace.FaRegular.AddressBook;
    private static Icon? f_AddressCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static Icon AddressCard => f_AddressCard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "address-card", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static Icon ContactCard => global::Someplace.FaRegular.AddressCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/address-card?f=classic&amp;s=regular">Address Card</a>
    /// </summary>
    public static Icon Vcard => global::Someplace.FaRegular.AddressCard;
    private static Icon? f_Bell;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bell?f=classic&amp;s=regular">Bell</a>
    /// </summary>
    public static Icon Bell => f_Bell ??= new Icon(IconFamily.Classic, IconStyle.Regular, "bell", "[unicode]");
    private static Icon? f_BellSlash;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bell-slash?f=classic&amp;s=regular">Bell Slash</a>
    /// </summary>
    public static Icon BellSlash => f_BellSlash ??= new Icon(IconFamily.Classic, IconStyle.Regular, "bell-slash", "[unicode]");
    private static Icon? f_Bookmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/bookmark?f=classic&amp;s=regular">Bookmark</a>
    /// </summary>
    public static Icon Bookmark => f_Bookmark ??= new Icon(IconFamily.Classic, IconStyle.Regular, "bookmark", "[unicode]");
    private static Icon? f_Building;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/building?f=classic&amp;s=regular">Building</a>
    /// </summary>
    public static Icon Building => f_Building ??= new Icon(IconFamily.Classic, IconStyle.Regular, "building", "[unicode]");
    private static Icon? f_Calendar;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar?f=classic&amp;s=regular">Calendar</a>
    /// </summary>
    public static Icon Calendar => f_Calendar ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar", "[unicode]");
    private static Icon? f_CalendarCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-check?f=classic&amp;s=regular">Calendar Check</a>
    /// </summary>
    public static Icon CalendarCheck => f_CalendarCheck ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar-check", "[unicode]");
    private static Icon? f_CalendarDays;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-days?f=classic&amp;s=regular">Calendar Days</a>
    /// </summary>
    public static Icon CalendarDays => f_CalendarDays ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar-days", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-days?f=classic&amp;s=regular">Calendar Days</a>
    /// </summary>
    public static Icon CalendarAlt => global::Someplace.FaRegular.CalendarDays;
    private static Icon? f_CalendarMinus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-minus?f=classic&amp;s=regular">Calendar Minus</a>
    /// </summary>
    public static Icon CalendarMinus => f_CalendarMinus ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar-minus", "[unicode]");
    private static Icon? f_CalendarPlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-plus?f=classic&amp;s=regular">Calendar Plus</a>
    /// </summary>
    public static Icon CalendarPlus => f_CalendarPlus ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar-plus", "[unicode]");
    private static Icon? f_CalendarXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-xmark?f=classic&amp;s=regular">Calendar Xmark</a>
    /// </summary>
    public static Icon CalendarXmark => f_CalendarXmark ??= new Icon(IconFamily.Classic, IconStyle.Regular, "calendar-xmark", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/calendar-xmark?f=classic&amp;s=regular">Calendar Xmark</a>
    /// </summary>
    public static Icon CalendarTimes => global::Someplace.FaRegular.CalendarXmark;
    private static Icon? f_ChartBar;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chart-bar?f=classic&amp;s=regular">Chart Bar</a>
    /// </summary>
    public static Icon ChartBar => f_ChartBar ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chart-bar", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chart-bar?f=classic&amp;s=regular">Chart Bar</a>
    /// </summary>
    public static Icon BarChart => global::Someplace.FaRegular.ChartBar;
    private static Icon? f_ChessBishop;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-bishop?f=classic&amp;s=regular">Chess Bishop</a>
    /// </summary>
    public static Icon ChessBishop => f_ChessBishop ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-bishop", "[unicode]");
    private static Icon? f_ChessKing;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-king?f=classic&amp;s=regular">Chess King</a>
    /// </summary>
    public static Icon ChessKing => f_ChessKing ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-king", "[unicode]");
    private static Icon? f_ChessKnight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-knight?f=classic&amp;s=regular">Chess Knight</a>
    /// </summary>
    public static Icon ChessKnight => f_ChessKnight ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-knight", "[unicode]");
    private static Icon? f_ChessPawn;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-pawn?f=classic&amp;s=regular">Chess Pawn</a>
    /// </summary>
    public static Icon ChessPawn => f_ChessPawn ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-pawn", "[unicode]");
    private static Icon? f_ChessQueen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-queen?f=classic&amp;s=regular">Chess Queen</a>
    /// </summary>
    public static Icon ChessQueen => f_ChessQueen ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-queen", "[unicode]");
    private static Icon? f_ChessRook;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/chess-rook?f=classic&amp;s=regular">Chess Rook</a>
    /// </summary>
    public static Icon ChessRook => f_ChessRook ??= new Icon(IconFamily.Classic, IconStyle.Regular, "chess-rook", "[unicode]");
    private static Icon? f_Circle;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle?f=classic&amp;s=regular">Circle</a>
    /// </summary>
    public static Icon Circle => f_Circle ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle", "[unicode]");
    private static Icon? f_CircleCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-check?f=classic&amp;s=regular">Circle Check</a>
    /// </summary>
    public static Icon CircleCheck => f_CircleCheck ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-check", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-check?f=classic&amp;s=regular">Circle Check</a>
    /// </summary>
    public static Icon CheckCircle => global::Someplace.FaRegular.CircleCheck;
    private static Icon? f_CircleDot;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-dot?f=classic&amp;s=regular">Circle Dot</a>
    /// </summary>
    public static Icon CircleDot => f_CircleDot ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-dot", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-dot?f=classic&amp;s=regular">Circle Dot</a>
    /// </summary>
    public static Icon DotCircle => global::Someplace.FaRegular.CircleDot;
    private static Icon? f_CircleDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-down?f=classic&amp;s=regular">Circle Down</a>
    /// </summary>
    public static Icon CircleDown => f_CircleDown ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-down", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-down?f=classic&amp;s=regular">Circle Down</a>
    /// </summary>
    public static Icon ArrowAltCircleDown => global::Someplace.FaRegular.CircleDown;
    private static Icon? f_CircleLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-left?f=classic&amp;s=regular">Circle Left</a>
    /// </summary>
    public static Icon CircleLeft => f_CircleLeft ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-left", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-left?f=classic&amp;s=regular">Circle Left</a>
    /// </summary>
    public static Icon ArrowAltCircleLeft => global::Someplace.FaRegular.CircleLeft;
    private static Icon? f_CirclePause;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-pause?f=classic&amp;s=regular">Circle Pause</a>
    /// </summary>
    public static Icon CirclePause => f_CirclePause ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-pause", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-pause?f=classic&amp;s=regular">Circle Pause</a>
    /// </summary>
    public static Icon PauseCircle => global::Someplace.FaRegular.CirclePause;
    private static Icon? f_CirclePlay;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-play?f=classic&amp;s=regular">Circle Play</a>
    /// </summary>
    public static Icon CirclePlay => f_CirclePlay ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-play", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-play?f=classic&amp;s=regular">Circle Play</a>
    /// </summary>
    public static Icon PlayCircle => global::Someplace.FaRegular.CirclePlay;
    private static Icon? f_CircleQuestion;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-question?f=classic&amp;s=regular">Circle Question</a>
    /// </summary>
    public static Icon CircleQuestion => f_CircleQuestion ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-question", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-question?f=classic&amp;s=regular">Circle Question</a>
    /// </summary>
    public static Icon QuestionCircle => global::Someplace.FaRegular.CircleQuestion;
    private static Icon? f_CircleRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-right?f=classic&amp;s=regular">Circle Right</a>
    /// </summary>
    public static Icon CircleRight => f_CircleRight ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-right", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-right?f=classic&amp;s=regular">Circle Right</a>
    /// </summary>
    public static Icon ArrowAltCircleRight => global::Someplace.FaRegular.CircleRight;
    private static Icon? f_CircleStop;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-stop?f=classic&amp;s=regular">Circle Stop</a>
    /// </summary>
    public static Icon CircleStop => f_CircleStop ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-stop", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-stop?f=classic&amp;s=regular">Circle Stop</a>
    /// </summary>
    public static Icon StopCircle => global::Someplace.FaRegular.CircleStop;
    private static Icon? f_CircleUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-up?f=classic&amp;s=regular">Circle Up</a>
    /// </summary>
    public static Icon CircleUp => f_CircleUp ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-up", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-up?f=classic&amp;s=regular">Circle Up</a>
    /// </summary>
    public static Icon ArrowAltCircleUp => global::Someplace.FaRegular.CircleUp;
    private static Icon? f_CircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-user?f=classic&amp;s=regular">Circle User</a>
    /// </summary>
    public static Icon CircleUser => f_CircleUser ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-user", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-user?f=classic&amp;s=regular">Circle User</a>
    /// </summary>
    public static Icon UserCircle => global::Someplace.FaRegular.CircleUser;
    private static Icon? f_CircleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static Icon CircleXmark => f_CircleXmark ??= new Icon(IconFamily.Classic, IconStyle.Regular, "circle-xmark", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static Icon TimesCircle => global::Someplace.FaRegular.CircleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/circle-xmark?f=classic&amp;s=regular">Circle Xmark</a>
    /// </summary>
    public static Icon XmarkCircle => global::Someplace.FaRegular.CircleXmark;
    private static Icon? f_Clipboard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clipboard?f=classic&amp;s=regular">Clipboard</a>
    /// </summary>
    public static Icon Clipboard => f_Clipboard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "clipboard", "[unicode]");
    private static Icon? f_Clock;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clock?f=classic&amp;s=regular">Clock</a>
    /// </summary>
    public static Icon Clock => f_Clock ??= new Icon(IconFamily.Classic, IconStyle.Regular, "clock", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clock?f=classic&amp;s=regular">Clock</a>
    /// </summary>
    public static Icon ClockFour => global::Someplace.FaRegular.Clock;
    private static Icon? f_Clone;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/clone?f=classic&amp;s=regular">Clone</a>
    /// </summary>
    public static Icon Clone => f_Clone ??= new Icon(IconFamily.Classic, IconStyle.Regular, "clone", "[unicode]");
    private static Icon? f_ClosedCaptioning;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/closed-captioning?f=classic&amp;s=regular">Closed Captioning</a>
    /// </summary>
    public static Icon ClosedCaptioning => f_ClosedCaptioning ??= new Icon(IconFamily.Classic, IconStyle.Regular, "closed-captioning", "[unicode]");
    private static Icon? f_Comment;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment?f=classic&amp;s=regular">Comment</a>
    /// </summary>
    public static Icon Comment => f_Comment ??= new Icon(IconFamily.Classic, IconStyle.Regular, "comment", "[unicode]");
    private static Icon? f_CommentDots;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment-dots?f=classic&amp;s=regular">Comment Dots</a>
    /// </summary>
    public static Icon CommentDots => f_CommentDots ??= new Icon(IconFamily.Classic, IconStyle.Regular, "comment-dots", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comment-dots?f=classic&amp;s=regular">Comment Dots</a>
    /// </summary>
    public static Icon Commenting => global::Someplace.FaRegular.CommentDots;
    private static Icon? f_Comments;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/comments?f=classic&amp;s=regular">Comments</a>
    /// </summary>
    public static Icon Comments => f_Comments ??= new Icon(IconFamily.Classic, IconStyle.Regular, "comments", "[unicode]");
    private static Icon? f_Compass;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/compass?f=classic&amp;s=regular">Compass</a>
    /// </summary>
    public static Icon Compass => f_Compass ??= new Icon(IconFamily.Classic, IconStyle.Regular, "compass", "[unicode]");
    private static Icon? f_Copy;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/copy?f=classic&amp;s=regular">Copy</a>
    /// </summary>
    public static Icon Copy => f_Copy ??= new Icon(IconFamily.Classic, IconStyle.Regular, "copy", "[unicode]");
    private static Icon? f_Copyright;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/copyright?f=classic&amp;s=regular">Copyright</a>
    /// </summary>
    public static Icon Copyright => f_Copyright ??= new Icon(IconFamily.Classic, IconStyle.Regular, "copyright", "[unicode]");
    private static Icon? f_CreditCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/credit-card?f=classic&amp;s=regular">Credit Card</a>
    /// </summary>
    public static Icon CreditCard => f_CreditCard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "credit-card", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/credit-card?f=classic&amp;s=regular">Credit Card</a>
    /// </summary>
    public static Icon CreditCardAlt => global::Someplace.FaRegular.CreditCard;
    private static Icon? f_Envelope;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/envelope?f=classic&amp;s=regular">Envelope</a>
    /// </summary>
    public static Icon Envelope => f_Envelope ??= new Icon(IconFamily.Classic, IconStyle.Regular, "envelope", "[unicode]");
    private static Icon? f_EnvelopeOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/envelope-open?f=classic&amp;s=regular">Envelope Open</a>
    /// </summary>
    public static Icon EnvelopeOpen => f_EnvelopeOpen ??= new Icon(IconFamily.Classic, IconStyle.Regular, "envelope-open", "[unicode]");
    private static Icon? f_Eye;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/eye?f=classic&amp;s=regular">Eye</a>
    /// </summary>
    public static Icon Eye => f_Eye ??= new Icon(IconFamily.Classic, IconStyle.Regular, "eye", "[unicode]");
    private static Icon? f_EyeSlash;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/eye-slash?f=classic&amp;s=regular">Eye Slash</a>
    /// </summary>
    public static Icon EyeSlash => f_EyeSlash ??= new Icon(IconFamily.Classic, IconStyle.Regular, "eye-slash", "[unicode]");
    private static Icon? f_FaceAngry;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-angry?f=classic&amp;s=regular">Face Angry</a>
    /// </summary>
    public static Icon FaceAngry => f_FaceAngry ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-angry", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-angry?f=classic&amp;s=regular">Face Angry</a>
    /// </summary>
    public static Icon Angry => global::Someplace.FaRegular.FaceAngry;
    private static Icon? f_FaceDizzy;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-dizzy?f=classic&amp;s=regular">Face Dizzy</a>
    /// </summary>
    public static Icon FaceDizzy => f_FaceDizzy ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-dizzy", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-dizzy?f=classic&amp;s=regular">Face Dizzy</a>
    /// </summary>
    public static Icon Dizzy => global::Someplace.FaRegular.FaceDizzy;
    private static Icon? f_FaceFlushed;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-flushed?f=classic&amp;s=regular">Face Flushed</a>
    /// </summary>
    public static Icon FaceFlushed => f_FaceFlushed ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-flushed", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-flushed?f=classic&amp;s=regular">Face Flushed</a>
    /// </summary>
    public static Icon Flushed => global::Someplace.FaRegular.FaceFlushed;
    private static Icon? f_FaceFrown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown?f=classic&amp;s=regular">Face Frown</a>
    /// </summary>
    public static Icon FaceFrown => f_FaceFrown ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-frown", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown?f=classic&amp;s=regular">Face Frown</a>
    /// </summary>
    public static Icon Frown => global::Someplace.FaRegular.FaceFrown;
    private static Icon? f_FaceFrownOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown-open?f=classic&amp;s=regular">Face Frown Open</a>
    /// </summary>
    public static Icon FaceFrownOpen => f_FaceFrownOpen ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-frown-open", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-frown-open?f=classic&amp;s=regular">Face Frown Open</a>
    /// </summary>
    public static Icon FrownOpen => global::Someplace.FaRegular.FaceFrownOpen;
    private static Icon? f_FaceGrimace;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grimace?f=classic&amp;s=regular">Face Grimace</a>
    /// </summary>
    public static Icon FaceGrimace => f_FaceGrimace ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grimace", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grimace?f=classic&amp;s=regular">Face Grimace</a>
    /// </summary>
    public static Icon Grimace => global::Someplace.FaRegular.FaceGrimace;
    private static Icon? f_FaceGrin;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin?f=classic&amp;s=regular">Face Grin</a>
    /// </summary>
    public static Icon FaceGrin => f_FaceGrin ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin?f=classic&amp;s=regular">Face Grin</a>
    /// </summary>
    public static Icon Grin => global::Someplace.FaRegular.FaceGrin;
    private static Icon? f_FaceGrinBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam?f=classic&amp;s=regular">Face Grin Beam</a>
    /// </summary>
    public static Icon FaceGrinBeam => f_FaceGrinBeam ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-beam", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam?f=classic&amp;s=regular">Face Grin Beam</a>
    /// </summary>
    public static Icon GrinBeam => global::Someplace.FaRegular.FaceGrinBeam;
    private static Icon? f_FaceGrinBeamSweat;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam-sweat?f=classic&amp;s=regular">Face Grin Beam Sweat</a>
    /// </summary>
    public static Icon FaceGrinBeamSweat => f_FaceGrinBeamSweat ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-beam-sweat", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-beam-sweat?f=classic&amp;s=regular">Face Grin Beam Sweat</a>
    /// </summary>
    public static Icon GrinBeamSweat => global::Someplace.FaRegular.FaceGrinBeamSweat;
    private static Icon? f_FaceGrinHearts;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-hearts?f=classic&amp;s=regular">Face Grin Hearts</a>
    /// </summary>
    public static Icon FaceGrinHearts => f_FaceGrinHearts ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-hearts", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-hearts?f=classic&amp;s=regular">Face Grin Hearts</a>
    /// </summary>
    public static Icon GrinHearts => global::Someplace.FaRegular.FaceGrinHearts;
    private static Icon? f_FaceGrinSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint?f=classic&amp;s=regular">Face Grin Squint</a>
    /// </summary>
    public static Icon FaceGrinSquint => f_FaceGrinSquint ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-squint", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint?f=classic&amp;s=regular">Face Grin Squint</a>
    /// </summary>
    public static Icon GrinSquint => global::Someplace.FaRegular.FaceGrinSquint;
    private static Icon? f_FaceGrinSquintTears;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint-tears?f=classic&amp;s=regular">Face Grin Squint Tears</a>
    /// </summary>
    public static Icon FaceGrinSquintTears => f_FaceGrinSquintTears ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-squint-tears", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-squint-tears?f=classic&amp;s=regular">Face Grin Squint Tears</a>
    /// </summary>
    public static Icon GrinSquintTears => global::Someplace.FaRegular.FaceGrinSquintTears;
    private static Icon? f_FaceGrinStars;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-stars?f=classic&amp;s=regular">Face Grin Stars</a>
    /// </summary>
    public static Icon FaceGrinStars => f_FaceGrinStars ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-stars", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-stars?f=classic&amp;s=regular">Face Grin Stars</a>
    /// </summary>
    public static Icon GrinStars => global::Someplace.FaRegular.FaceGrinStars;
    private static Icon? f_FaceGrinTears;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tears?f=classic&amp;s=regular">Face Grin Tears</a>
    /// </summary>
    public static Icon FaceGrinTears => f_FaceGrinTears ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-tears", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tears?f=classic&amp;s=regular">Face Grin Tears</a>
    /// </summary>
    public static Icon GrinTears => global::Someplace.FaRegular.FaceGrinTears;
    private static Icon? f_FaceGrinTongue;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue?f=classic&amp;s=regular">Face Grin Tongue</a>
    /// </summary>
    public static Icon FaceGrinTongue => f_FaceGrinTongue ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue?f=classic&amp;s=regular">Face Grin Tongue</a>
    /// </summary>
    public static Icon GrinTongue => global::Someplace.FaRegular.FaceGrinTongue;
    private static Icon? f_FaceGrinTongueSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-squint?f=classic&amp;s=regular">Face Grin Tongue Squint</a>
    /// </summary>
    public static Icon FaceGrinTongueSquint => f_FaceGrinTongueSquint ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue-squint", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-squint?f=classic&amp;s=regular">Face Grin Tongue Squint</a>
    /// </summary>
    public static Icon GrinTongueSquint => global::Someplace.FaRegular.FaceGrinTongueSquint;
    private static Icon? f_FaceGrinTongueWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-wink?f=classic&amp;s=regular">Face Grin Tongue Wink</a>
    /// </summary>
    public static Icon FaceGrinTongueWink => f_FaceGrinTongueWink ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-tongue-wink", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-tongue-wink?f=classic&amp;s=regular">Face Grin Tongue Wink</a>
    /// </summary>
    public static Icon GrinTongueWink => global::Someplace.FaRegular.FaceGrinTongueWink;
    private static Icon? f_FaceGrinWide;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wide?f=classic&amp;s=regular">Face Grin Wide</a>
    /// </summary>
    public static Icon FaceGrinWide => f_FaceGrinWide ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-wide", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wide?f=classic&amp;s=regular">Face Grin Wide</a>
    /// </summary>
    public static Icon GrinAlt => global::Someplace.FaRegular.FaceGrinWide;
    private static Icon? f_FaceGrinWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wink?f=classic&amp;s=regular">Face Grin Wink</a>
    /// </summary>
    public static Icon FaceGrinWink => f_FaceGrinWink ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-grin-wink", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-grin-wink?f=classic&amp;s=regular">Face Grin Wink</a>
    /// </summary>
    public static Icon GrinWink => global::Someplace.FaRegular.FaceGrinWink;
    private static Icon? f_FaceKiss;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss?f=classic&amp;s=regular">Face Kiss</a>
    /// </summary>
    public static Icon FaceKiss => f_FaceKiss ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-kiss", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss?f=classic&amp;s=regular">Face Kiss</a>
    /// </summary>
    public static Icon Kiss => global::Someplace.FaRegular.FaceKiss;
    private static Icon? f_FaceKissBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-beam?f=classic&amp;s=regular">Face Kiss Beam</a>
    /// </summary>
    public static Icon FaceKissBeam => f_FaceKissBeam ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-kiss-beam", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-beam?f=classic&amp;s=regular">Face Kiss Beam</a>
    /// </summary>
    public static Icon KissBeam => global::Someplace.FaRegular.FaceKissBeam;
    private static Icon? f_FaceKissWinkHeart;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-wink-heart?f=classic&amp;s=regular">Face Kiss Wink Heart</a>
    /// </summary>
    public static Icon FaceKissWinkHeart => f_FaceKissWinkHeart ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-kiss-wink-heart", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-kiss-wink-heart?f=classic&amp;s=regular">Face Kiss Wink Heart</a>
    /// </summary>
    public static Icon KissWinkHeart => global::Someplace.FaRegular.FaceKissWinkHeart;
    private static Icon? f_FaceLaugh;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh?f=classic&amp;s=regular">Face Laugh</a>
    /// </summary>
    public static Icon FaceLaugh => f_FaceLaugh ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-laugh", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh?f=classic&amp;s=regular">Face Laugh</a>
    /// </summary>
    public static Icon Laugh => global::Someplace.FaRegular.FaceLaugh;
    private static Icon? f_FaceLaughBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-beam?f=classic&amp;s=regular">Face Laugh Beam</a>
    /// </summary>
    public static Icon FaceLaughBeam => f_FaceLaughBeam ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-laugh-beam", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-beam?f=classic&amp;s=regular">Face Laugh Beam</a>
    /// </summary>
    public static Icon LaughBeam => global::Someplace.FaRegular.FaceLaughBeam;
    private static Icon? f_FaceLaughSquint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-squint?f=classic&amp;s=regular">Face Laugh Squint</a>
    /// </summary>
    public static Icon FaceLaughSquint => f_FaceLaughSquint ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-laugh-squint", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-squint?f=classic&amp;s=regular">Face Laugh Squint</a>
    /// </summary>
    public static Icon LaughSquint => global::Someplace.FaRegular.FaceLaughSquint;
    private static Icon? f_FaceLaughWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-wink?f=classic&amp;s=regular">Face Laugh Wink</a>
    /// </summary>
    public static Icon FaceLaughWink => f_FaceLaughWink ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-laugh-wink", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-laugh-wink?f=classic&amp;s=regular">Face Laugh Wink</a>
    /// </summary>
    public static Icon LaughWink => global::Someplace.FaRegular.FaceLaughWink;
    private static Icon? f_FaceMeh;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh?f=classic&amp;s=regular">Face Meh</a>
    /// </summary>
    public static Icon FaceMeh => f_FaceMeh ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-meh", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh?f=classic&amp;s=regular">Face Meh</a>
    /// </summary>
    public static Icon Meh => global::Someplace.FaRegular.FaceMeh;
    private static Icon? f_FaceMehBlank;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh-blank?f=classic&amp;s=regular">Face Meh Blank</a>
    /// </summary>
    public static Icon FaceMehBlank => f_FaceMehBlank ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-meh-blank", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-meh-blank?f=classic&amp;s=regular">Face Meh Blank</a>
    /// </summary>
    public static Icon MehBlank => global::Someplace.FaRegular.FaceMehBlank;
    private static Icon? f_FaceRollingEyes;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-rolling-eyes?f=classic&amp;s=regular">Face Rolling Eyes</a>
    /// </summary>
    public static Icon FaceRollingEyes => f_FaceRollingEyes ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-rolling-eyes", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-rolling-eyes?f=classic&amp;s=regular">Face Rolling Eyes</a>
    /// </summary>
    public static Icon MehRollingEyes => global::Someplace.FaRegular.FaceRollingEyes;
    private static Icon? f_FaceSadCry;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-cry?f=classic&amp;s=regular">Face Sad Cry</a>
    /// </summary>
    public static Icon FaceSadCry => f_FaceSadCry ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-sad-cry", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-cry?f=classic&amp;s=regular">Face Sad Cry</a>
    /// </summary>
    public static Icon SadCry => global::Someplace.FaRegular.FaceSadCry;
    private static Icon? f_FaceSadTear;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-tear?f=classic&amp;s=regular">Face Sad Tear</a>
    /// </summary>
    public static Icon FaceSadTear => f_FaceSadTear ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-sad-tear", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-sad-tear?f=classic&amp;s=regular">Face Sad Tear</a>
    /// </summary>
    public static Icon SadTear => global::Someplace.FaRegular.FaceSadTear;
    private static Icon? f_FaceSmile;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile?f=classic&amp;s=regular">Face Smile</a>
    /// </summary>
    public static Icon FaceSmile => f_FaceSmile ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-smile", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile?f=classic&amp;s=regular">Face Smile</a>
    /// </summary>
    public static Icon Smile => global::Someplace.FaRegular.FaceSmile;
    private static Icon? f_FaceSmileBeam;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-beam?f=classic&amp;s=regular">Face Smile Beam</a>
    /// </summary>
    public static Icon FaceSmileBeam => f_FaceSmileBeam ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-smile-beam", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-beam?f=classic&amp;s=regular">Face Smile Beam</a>
    /// </summary>
    public static Icon SmileBeam => global::Someplace.FaRegular.FaceSmileBeam;
    private static Icon? f_FaceSmileWink;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-wink?f=classic&amp;s=regular">Face Smile Wink</a>
    /// </summary>
    public static Icon FaceSmileWink => f_FaceSmileWink ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-smile-wink", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-smile-wink?f=classic&amp;s=regular">Face Smile Wink</a>
    /// </summary>
    public static Icon SmileWink => global::Someplace.FaRegular.FaceSmileWink;
    private static Icon? f_FaceSurprise;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-surprise?f=classic&amp;s=regular">Face Surprise</a>
    /// </summary>
    public static Icon FaceSurprise => f_FaceSurprise ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-surprise", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-surprise?f=classic&amp;s=regular">Face Surprise</a>
    /// </summary>
    public static Icon Surprise => global::Someplace.FaRegular.FaceSurprise;
    private static Icon? f_FaceTired;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-tired?f=classic&amp;s=regular">Face Tired</a>
    /// </summary>
    public static Icon FaceTired => f_FaceTired ??= new Icon(IconFamily.Classic, IconStyle.Regular, "face-tired", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/face-tired?f=classic&amp;s=regular">Face Tired</a>
    /// </summary>
    public static Icon Tired => global::Someplace.FaRegular.FaceTired;
    private static Icon? f_File;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file?f=classic&amp;s=regular">File</a>
    /// </summary>
    public static Icon File => f_File ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file", "[unicode]");
    private static Icon? f_FileAudio;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-audio?f=classic&amp;s=regular">File Audio</a>
    /// </summary>
    public static Icon FileAudio => f_FileAudio ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-audio", "[unicode]");
    private static Icon? f_FileCode;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-code?f=classic&amp;s=regular">File Code</a>
    /// </summary>
    public static Icon FileCode => f_FileCode ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-code", "[unicode]");
    private static Icon? f_FileExcel;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-excel?f=classic&amp;s=regular">File Excel</a>
    /// </summary>
    public static Icon FileExcel => f_FileExcel ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-excel", "[unicode]");
    private static Icon? f_FileImage;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-image?f=classic&amp;s=regular">File Image</a>
    /// </summary>
    public static Icon FileImage => f_FileImage ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-image", "[unicode]");
    private static Icon? f_FileLines;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static Icon FileLines => f_FileLines ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-lines", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static Icon FileAlt => global::Someplace.FaRegular.FileLines;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-lines?f=classic&amp;s=regular">File Lines</a>
    /// </summary>
    public static Icon FileText => global::Someplace.FaRegular.FileLines;
    private static Icon? f_FilePdf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-pdf?f=classic&amp;s=regular">File Pdf</a>
    /// </summary>
    public static Icon FilePdf => f_FilePdf ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-pdf", "[unicode]");
    private static Icon? f_FilePowerpoint;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-powerpoint?f=classic&amp;s=regular">File Powerpoint</a>
    /// </summary>
    public static Icon FilePowerpoint => f_FilePowerpoint ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-powerpoint", "[unicode]");
    private static Icon? f_FileVideo;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-video?f=classic&amp;s=regular">File Video</a>
    /// </summary>
    public static Icon FileVideo => f_FileVideo ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-video", "[unicode]");
    private static Icon? f_FileWord;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-word?f=classic&amp;s=regular">File Word</a>
    /// </summary>
    public static Icon FileWord => f_FileWord ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-word", "[unicode]");
    private static Icon? f_FileZipper;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-zipper?f=classic&amp;s=regular">File Zipper</a>
    /// </summary>
    public static Icon FileZipper => f_FileZipper ??= new Icon(IconFamily.Classic, IconStyle.Regular, "file-zipper", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/file-zipper?f=classic&amp;s=regular">File Zipper</a>
    /// </summary>
    public static Icon FileArchive => global::Someplace.FaRegular.FileZipper;
    private static Icon? f_Flag;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/flag?f=classic&amp;s=regular">Flag</a>
    /// </summary>
    public static Icon Flag => f_Flag ??= new Icon(IconFamily.Classic, IconStyle.Regular, "flag", "[unicode]");
    private static Icon? f_FloppyDisk;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/floppy-disk?f=classic&amp;s=regular">Floppy Disk</a>
    /// </summary>
    public static Icon FloppyDisk => f_FloppyDisk ??= new Icon(IconFamily.Classic, IconStyle.Regular, "floppy-disk", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/floppy-disk?f=classic&amp;s=regular">Floppy Disk</a>
    /// </summary>
    public static Icon Save => global::Someplace.FaRegular.FloppyDisk;
    private static Icon? f_Folder;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder?f=classic&amp;s=regular">Folder</a>
    /// </summary>
    public static Icon Folder => f_Folder ??= new Icon(IconFamily.Classic, IconStyle.Regular, "folder", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder?f=classic&amp;s=regular">Folder</a>
    /// </summary>
    public static Icon FolderBlank => global::Someplace.FaRegular.Folder;
    private static Icon? f_FolderClosed;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder-closed?f=classic&amp;s=regular">Folder Closed</a>
    /// </summary>
    public static Icon FolderClosed => f_FolderClosed ??= new Icon(IconFamily.Classic, IconStyle.Regular, "folder-closed", "[unicode]");
    private static Icon? f_FolderOpen;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/folder-open?f=classic&amp;s=regular">Folder Open</a>
    /// </summary>
    public static Icon FolderOpen => f_FolderOpen ??= new Icon(IconFamily.Classic, IconStyle.Regular, "folder-open", "[unicode]");
    private static Icon? f_FontAwesome;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static Icon FontAwesome => f_FontAwesome ??= new Icon(IconFamily.Classic, IconStyle.Regular, "font-awesome", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static Icon FontAwesomeFlag => global::Someplace.FaRegular.FontAwesome;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/font-awesome?f=classic&amp;s=regular">Font Awesome</a>
    /// </summary>
    public static Icon FontAwesomeLogoFull => global::Someplace.FaRegular.FontAwesome;
    private static Icon? f_Futbol;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static Icon Futbol => f_Futbol ??= new Icon(IconFamily.Classic, IconStyle.Regular, "futbol", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static Icon FutbolBall => global::Someplace.FaRegular.Futbol;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/futbol?f=classic&amp;s=regular">Futbol</a>
    /// </summary>
    public static Icon SoccerBall => global::Someplace.FaRegular.Futbol;
    private static Icon? f_Gem;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/gem?f=classic&amp;s=regular">Gem</a>
    /// </summary>
    public static Icon Gem => f_Gem ??= new Icon(IconFamily.Classic, IconStyle.Regular, "gem", "[unicode]");
    private static Icon? f_Hand;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand?f=classic&amp;s=regular">Hand</a>
    /// </summary>
    public static Icon Hand => f_Hand ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand?f=classic&amp;s=regular">Hand</a>
    /// </summary>
    public static Icon HandPaper => global::Someplace.FaRegular.Hand;
    private static Icon? f_HandBackFist;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-back-fist?f=classic&amp;s=regular">Hand Back Fist</a>
    /// </summary>
    public static Icon HandBackFist => f_HandBackFist ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-back-fist", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-back-fist?f=classic&amp;s=regular">Hand Back Fist</a>
    /// </summary>
    public static Icon HandRock => global::Someplace.FaRegular.HandBackFist;
    private static Icon? f_HandLizard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-lizard?f=classic&amp;s=regular">Hand Lizard</a>
    /// </summary>
    public static Icon HandLizard => f_HandLizard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-lizard", "[unicode]");
    private static Icon? f_HandPeace;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-peace?f=classic&amp;s=regular">Hand Peace</a>
    /// </summary>
    public static Icon HandPeace => f_HandPeace ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-peace", "[unicode]");
    private static Icon? f_HandPointDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-down?f=classic&amp;s=regular">Hand Point Down</a>
    /// </summary>
    public static Icon HandPointDown => f_HandPointDown ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-point-down", "[unicode]");
    private static Icon? f_HandPointLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-left?f=classic&amp;s=regular">Hand Point Left</a>
    /// </summary>
    public static Icon HandPointLeft => f_HandPointLeft ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-point-left", "[unicode]");
    private static Icon? f_HandPointRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-right?f=classic&amp;s=regular">Hand Point Right</a>
    /// </summary>
    public static Icon HandPointRight => f_HandPointRight ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-point-right", "[unicode]");
    private static Icon? f_HandPointUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-point-up?f=classic&amp;s=regular">Hand Point Up</a>
    /// </summary>
    public static Icon HandPointUp => f_HandPointUp ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-point-up", "[unicode]");
    private static Icon? f_HandPointer;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-pointer?f=classic&amp;s=regular">Hand Pointer</a>
    /// </summary>
    public static Icon HandPointer => f_HandPointer ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-pointer", "[unicode]");
    private static Icon? f_HandScissors;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-scissors?f=classic&amp;s=regular">Hand Scissors</a>
    /// </summary>
    public static Icon HandScissors => f_HandScissors ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-scissors", "[unicode]");
    private static Icon? f_HandSpock;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hand-spock?f=classic&amp;s=regular">Hand Spock</a>
    /// </summary>
    public static Icon HandSpock => f_HandSpock ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hand-spock", "[unicode]");
    private static Icon? f_Handshake;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/handshake?f=classic&amp;s=regular">Handshake</a>
    /// </summary>
    public static Icon Handshake => f_Handshake ??= new Icon(IconFamily.Classic, IconStyle.Regular, "handshake", "[unicode]");
    private static Icon? f_HardDrive;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hard-drive?f=classic&amp;s=regular">Hard Drive</a>
    /// </summary>
    public static Icon HardDrive => f_HardDrive ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hard-drive", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hard-drive?f=classic&amp;s=regular">Hard Drive</a>
    /// </summary>
    public static Icon Hdd => global::Someplace.FaRegular.HardDrive;
    private static Icon? f_Heart;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/heart?f=classic&amp;s=regular">Heart</a>
    /// </summary>
    public static Icon Heart => f_Heart ??= new Icon(IconFamily.Classic, IconStyle.Regular, "heart", "[unicode]");
    private static Icon? f_Hospital;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static Icon Hospital => f_Hospital ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hospital", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static Icon HospitalAlt => global::Someplace.FaRegular.Hospital;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hospital?f=classic&amp;s=regular">Hospital</a>
    /// </summary>
    public static Icon HospitalWide => global::Someplace.FaRegular.Hospital;
    private static Icon? f_Hourglass;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass?f=classic&amp;s=regular">Hourglass</a>
    /// </summary>
    public static Icon Hourglass => f_Hourglass ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hourglass", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass?f=classic&amp;s=regular">Hourglass</a>
    /// </summary>
    public static Icon HourglassEmpty => global::Someplace.FaRegular.Hourglass;
    private static Icon? f_HourglassHalf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass-half?f=classic&amp;s=regular">Hourglass Half</a>
    /// </summary>
    public static Icon HourglassHalf => f_HourglassHalf ??= new Icon(IconFamily.Classic, IconStyle.Regular, "hourglass-half", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/hourglass-half?f=classic&amp;s=regular">Hourglass Half</a>
    /// </summary>
    public static Icon Hourglass2 => global::Someplace.FaRegular.HourglassHalf;
    private static Icon? f_IdBadge;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-badge?f=classic&amp;s=regular">Id Badge</a>
    /// </summary>
    public static Icon IdBadge => f_IdBadge ??= new Icon(IconFamily.Classic, IconStyle.Regular, "id-badge", "[unicode]");
    private static Icon? f_IdCard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-card?f=classic&amp;s=regular">Id Card</a>
    /// </summary>
    public static Icon IdCard => f_IdCard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "id-card", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/id-card?f=classic&amp;s=regular">Id Card</a>
    /// </summary>
    public static Icon DriversLicense => global::Someplace.FaRegular.IdCard;
    private static Icon? f_Image;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/image?f=classic&amp;s=regular">Image</a>
    /// </summary>
    public static Icon Image => f_Image ??= new Icon(IconFamily.Classic, IconStyle.Regular, "image", "[unicode]");
    private static Icon? f_Images;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/images?f=classic&amp;s=regular">Images</a>
    /// </summary>
    public static Icon Images => f_Images ??= new Icon(IconFamily.Classic, IconStyle.Regular, "images", "[unicode]");
    private static Icon? f_Keyboard;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/keyboard?f=classic&amp;s=regular">Keyboard</a>
    /// </summary>
    public static Icon Keyboard => f_Keyboard ??= new Icon(IconFamily.Classic, IconStyle.Regular, "keyboard", "[unicode]");
    private static Icon? f_Lemon;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/lemon?f=classic&amp;s=regular">Lemon</a>
    /// </summary>
    public static Icon Lemon => f_Lemon ??= new Icon(IconFamily.Classic, IconStyle.Regular, "lemon", "[unicode]");
    private static Icon? f_LifeRing;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/life-ring?f=classic&amp;s=regular">Life Ring</a>
    /// </summary>
    public static Icon LifeRing => f_LifeRing ??= new Icon(IconFamily.Classic, IconStyle.Regular, "life-ring", "[unicode]");
    private static Icon? f_Lightbulb;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/lightbulb?f=classic&amp;s=regular">Lightbulb</a>
    /// </summary>
    public static Icon Lightbulb => f_Lightbulb ??= new Icon(IconFamily.Classic, IconStyle.Regular, "lightbulb", "[unicode]");
    private static Icon? f_Map;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/map?f=classic&amp;s=regular">Map</a>
    /// </summary>
    public static Icon Map => f_Map ??= new Icon(IconFamily.Classic, IconStyle.Regular, "map", "[unicode]");
    private static Icon? f_Message;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/message?f=classic&amp;s=regular">Message</a>
    /// </summary>
    public static Icon Message => f_Message ??= new Icon(IconFamily.Classic, IconStyle.Regular, "message", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/message?f=classic&amp;s=regular">Message</a>
    /// </summary>
    public static Icon CommentAlt => global::Someplace.FaRegular.Message;
    private static Icon? f_MoneyBill1;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/money-bill-1?f=classic&amp;s=regular">Money Bill 1</a>
    /// </summary>
    public static Icon MoneyBill1 => f_MoneyBill1 ??= new Icon(IconFamily.Classic, IconStyle.Regular, "money-bill-1", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/money-bill-1?f=classic&amp;s=regular">Money Bill 1</a>
    /// </summary>
    public static Icon MoneyBillAlt => global::Someplace.FaRegular.MoneyBill1;
    private static Icon? f_Moon;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/moon?f=classic&amp;s=regular">Moon</a>
    /// </summary>
    public static Icon Moon => f_Moon ??= new Icon(IconFamily.Classic, IconStyle.Regular, "moon", "[unicode]");
    private static Icon? f_Newspaper;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/newspaper?f=classic&amp;s=regular">Newspaper</a>
    /// </summary>
    public static Icon Newspaper => f_Newspaper ??= new Icon(IconFamily.Classic, IconStyle.Regular, "newspaper", "[unicode]");
    private static Icon? f_NoteSticky;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/note-sticky?f=classic&amp;s=regular">Note Sticky</a>
    /// </summary>
    public static Icon NoteSticky => f_NoteSticky ??= new Icon(IconFamily.Classic, IconStyle.Regular, "note-sticky", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/note-sticky?f=classic&amp;s=regular">Note Sticky</a>
    /// </summary>
    public static Icon StickyNote => global::Someplace.FaRegular.NoteSticky;
    private static Icon? f_ObjectGroup;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/object-group?f=classic&amp;s=regular">Object Group</a>
    /// </summary>
    public static Icon ObjectGroup => f_ObjectGroup ??= new Icon(IconFamily.Classic, IconStyle.Regular, "object-group", "[unicode]");
    private static Icon? f_ObjectUngroup;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/object-ungroup?f=classic&amp;s=regular">Object Ungroup</a>
    /// </summary>
    public static Icon ObjectUngroup => f_ObjectUngroup ??= new Icon(IconFamily.Classic, IconStyle.Regular, "object-ungroup", "[unicode]");
    private static Icon? f_PaperPlane;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paper-plane?f=classic&amp;s=regular">Paper Plane</a>
    /// </summary>
    public static Icon PaperPlane => f_PaperPlane ??= new Icon(IconFamily.Classic, IconStyle.Regular, "paper-plane", "[unicode]");
    private static Icon? f_Paste;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paste?f=classic&amp;s=regular">Paste</a>
    /// </summary>
    public static Icon Paste => f_Paste ??= new Icon(IconFamily.Classic, IconStyle.Regular, "paste", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/paste?f=classic&amp;s=regular">Paste</a>
    /// </summary>
    public static Icon FileClipboard => global::Someplace.FaRegular.Paste;
    private static Icon? f_PenToSquare;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/pen-to-square?f=classic&amp;s=regular">Pen To Square</a>
    /// </summary>
    public static Icon PenToSquare => f_PenToSquare ??= new Icon(IconFamily.Classic, IconStyle.Regular, "pen-to-square", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/pen-to-square?f=classic&amp;s=regular">Pen To Square</a>
    /// </summary>
    public static Icon Edit => global::Someplace.FaRegular.PenToSquare;
    private static Icon? f_RectangleList;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-list?f=classic&amp;s=regular">Rectangle List</a>
    /// </summary>
    public static Icon RectangleList => f_RectangleList ??= new Icon(IconFamily.Classic, IconStyle.Regular, "rectangle-list", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-list?f=classic&amp;s=regular">Rectangle List</a>
    /// </summary>
    public static Icon ListAlt => global::Someplace.FaRegular.RectangleList;
    private static Icon? f_RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static Icon RectangleXmark => f_RectangleXmark ??= new Icon(IconFamily.Classic, IconStyle.Regular, "rectangle-xmark", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static Icon RectangleTimes => global::Someplace.FaRegular.RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static Icon TimesRectangle => global::Someplace.FaRegular.RectangleXmark;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/rectangle-xmark?f=classic&amp;s=regular">Rectangle Xmark</a>
    /// </summary>
    public static Icon WindowClose => global::Someplace.FaRegular.RectangleXmark;
    private static Icon? f_Registered;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/registered?f=classic&amp;s=regular">Registered</a>
    /// </summary>
    public static Icon Registered => f_Registered ??= new Icon(IconFamily.Classic, IconStyle.Regular, "registered", "[unicode]");
    private static Icon? f_ShareFromSquare;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/share-from-square?f=classic&amp;s=regular">Share From Square</a>
    /// </summary>
    public static Icon ShareFromSquare => f_ShareFromSquare ??= new Icon(IconFamily.Classic, IconStyle.Regular, "share-from-square", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/share-from-square?f=classic&amp;s=regular">Share From Square</a>
    /// </summary>
    public static Icon ShareSquare => global::Someplace.FaRegular.ShareFromSquare;
    private static Icon? f_Snowflake;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/snowflake?f=classic&amp;s=regular">Snowflake</a>
    /// </summary>
    public static Icon Snowflake => f_Snowflake ??= new Icon(IconFamily.Classic, IconStyle.Regular, "snowflake", "[unicode]");
    private static Icon? f_Square;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square?f=classic&amp;s=regular">Square</a>
    /// </summary>
    public static Icon Square => f_Square ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square", "[unicode]");
    private static Icon? f_SquareCaretDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-down?f=classic&amp;s=regular">Square Caret Down</a>
    /// </summary>
    public static Icon SquareCaretDown => f_SquareCaretDown ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-caret-down", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-down?f=classic&amp;s=regular">Square Caret Down</a>
    /// </summary>
    public static Icon CaretSquareDown => global::Someplace.FaRegular.SquareCaretDown;
    private static Icon? f_SquareCaretLeft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-left?f=classic&amp;s=regular">Square Caret Left</a>
    /// </summary>
    public static Icon SquareCaretLeft => f_SquareCaretLeft ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-caret-left", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-left?f=classic&amp;s=regular">Square Caret Left</a>
    /// </summary>
    public static Icon CaretSquareLeft => global::Someplace.FaRegular.SquareCaretLeft;
    private static Icon? f_SquareCaretRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-right?f=classic&amp;s=regular">Square Caret Right</a>
    /// </summary>
    public static Icon SquareCaretRight => f_SquareCaretRight ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-caret-right", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-right?f=classic&amp;s=regular">Square Caret Right</a>
    /// </summary>
    public static Icon CaretSquareRight => global::Someplace.FaRegular.SquareCaretRight;
    private static Icon? f_SquareCaretUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-up?f=classic&amp;s=regular">Square Caret Up</a>
    /// </summary>
    public static Icon SquareCaretUp => f_SquareCaretUp ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-caret-up", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-caret-up?f=classic&amp;s=regular">Square Caret Up</a>
    /// </summary>
    public static Icon CaretSquareUp => global::Someplace.FaRegular.SquareCaretUp;
    private static Icon? f_SquareCheck;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-check?f=classic&amp;s=regular">Square Check</a>
    /// </summary>
    public static Icon SquareCheck => f_SquareCheck ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-check", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-check?f=classic&amp;s=regular">Square Check</a>
    /// </summary>
    public static Icon CheckSquare => global::Someplace.FaRegular.SquareCheck;
    private static Icon? f_SquareFull;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-full?f=classic&amp;s=regular">Square Full</a>
    /// </summary>
    public static Icon SquareFull => f_SquareFull ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-full", "[unicode]");
    private static Icon? f_SquareMinus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-minus?f=classic&amp;s=regular">Square Minus</a>
    /// </summary>
    public static Icon SquareMinus => f_SquareMinus ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-minus", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-minus?f=classic&amp;s=regular">Square Minus</a>
    /// </summary>
    public static Icon MinusSquare => global::Someplace.FaRegular.SquareMinus;
    private static Icon? f_SquarePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-plus?f=classic&amp;s=regular">Square Plus</a>
    /// </summary>
    public static Icon SquarePlus => f_SquarePlus ??= new Icon(IconFamily.Classic, IconStyle.Regular, "square-plus", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/square-plus?f=classic&amp;s=regular">Square Plus</a>
    /// </summary>
    public static Icon PlusSquare => global::Someplace.FaRegular.SquarePlus;
    private static Icon? f_Star;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star?f=classic&amp;s=regular">Star</a>
    /// </summary>
    public static Icon Star => f_Star ??= new Icon(IconFamily.Classic, IconStyle.Regular, "star", "[unicode]");
    private static Icon? f_StarHalf;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half?f=classic&amp;s=regular">Star Half</a>
    /// </summary>
    public static Icon StarHalf => f_StarHalf ??= new Icon(IconFamily.Classic, IconStyle.Regular, "star-half", "[unicode]");
    private static Icon? f_StarHalfStroke;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half-stroke?f=classic&amp;s=regular">Star Half Stroke</a>
    /// </summary>
    public static Icon StarHalfStroke => f_StarHalfStroke ??= new Icon(IconFamily.Classic, IconStyle.Regular, "star-half-stroke", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/star-half-stroke?f=classic&amp;s=regular">Star Half Stroke</a>
    /// </summary>
    public static Icon StarHalfAlt => global::Someplace.FaRegular.StarHalfStroke;
    private static Icon? f_Sun;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/sun?f=classic&amp;s=regular">Sun</a>
    /// </summary>
    public static Icon Sun => f_Sun ??= new Icon(IconFamily.Classic, IconStyle.Regular, "sun", "[unicode]");
    private static Icon? f_ThumbsDown;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/thumbs-down?f=classic&amp;s=regular">Thumbs Down</a>
    /// </summary>
    public static Icon ThumbsDown => f_ThumbsDown ??= new Icon(IconFamily.Classic, IconStyle.Regular, "thumbs-down", "[unicode]");
    private static Icon? f_ThumbsUp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/thumbs-up?f=classic&amp;s=regular">Thumbs Up</a>
    /// </summary>
    public static Icon ThumbsUp => f_ThumbsUp ??= new Icon(IconFamily.Classic, IconStyle.Regular, "thumbs-up", "[unicode]");
    private static Icon? f_TrashCan;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/trash-can?f=classic&amp;s=regular">Trash Can</a>
    /// </summary>
    public static Icon TrashCan => f_TrashCan ??= new Icon(IconFamily.Classic, IconStyle.Regular, "trash-can", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/trash-can?f=classic&amp;s=regular">Trash Can</a>
    /// </summary>
    public static Icon TrashAlt => global::Someplace.FaRegular.TrashCan;
    private static Icon? f_User;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&amp;s=regular">User</a>
    /// </summary>
    public static Icon User => f_User ??= new Icon(IconFamily.Classic, IconStyle.Regular, "user", "[unicode]");
    private static Icon? f_WindowMaximize;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-maximize?f=classic&amp;s=regular">Window Maximize</a>
    /// </summary>
    public static Icon WindowMaximize => f_WindowMaximize ??= new Icon(IconFamily.Classic, IconStyle.Regular, "window-maximize", "[unicode]");
    private static Icon? f_WindowMinimize;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-minimize?f=classic&amp;s=regular">Window Minimize</a>
    /// </summary>
    public static Icon WindowMinimize => f_WindowMinimize ??= new Icon(IconFamily.Classic, IconStyle.Regular, "window-minimize", "[unicode]");
    private static Icon? f_WindowRestore;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/window-restore?f=classic&amp;s=regular">Window Restore</a>
    /// </summary>
    public static Icon WindowRestore => f_WindowRestore ??= new Icon(IconFamily.Classic, IconStyle.Regular, "window-restore", "[unicode]");
}