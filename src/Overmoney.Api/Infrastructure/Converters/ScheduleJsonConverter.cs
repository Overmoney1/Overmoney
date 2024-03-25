﻿using Overmoney.Api.Features.Transactions.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Overmoney.Api.Infrastructure.Converters;

internal sealed class ScheduleJsonConverter : JsonConverter<Schedule>
{
    public override Schedule Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new Schedule(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, Schedule value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Cron);
    }
}
