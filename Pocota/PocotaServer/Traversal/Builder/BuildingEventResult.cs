namespace Net.Leksi.Pocota.Builder;

internal enum BuildingEventResult
{
    Matching,
    Matched,
    Missed,
    KeyNotSet,
    NotNullableSetNull,
    Exception
}
