using ConcertBooking.Api.Modules.Concert.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Concert.Domain.Entities;
public class Concert : BaseEntity
{
    private readonly List<TicketCategory> _ticketCategories = [];

    private Concert()
    {
    }

    public Concert(
        string name,
        string description,
        string venue,
        DateTime startTime,
        DateTime endTime)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Concert name is required.", nameof(name));

        if (string.IsNullOrWhiteSpace(venue))
            throw new ArgumentException("Venue is required.", nameof(venue));

        if (endTime <= startTime)
            throw new ArgumentException("End time must be after start time.");

        Name = name.Trim();
        Description = description.Trim();
        Venue = venue.Trim();
        StartTime = startTime;
        EndTime = endTime;

        Status = ConcertStatus.Draft;
    }

    public string Name { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public string Venue { get; private set; } = default!;

    public DateTime StartTime { get; private set; }

    public DateTime EndTime { get; private set; }

    public ConcertStatus Status { get; private set; }

    public IReadOnlyCollection<TicketCategory> TicketCategories
        => _ticketCategories.AsReadOnly();

    public void Publish()
    {
        if (Status != ConcertStatus.Draft)
            throw new InvalidOperationException(
                "Only draft concert can be published.");

        if (_ticketCategories.Count == 0)
            throw new InvalidOperationException(
                "Concert must have at least one ticket category.");

        Status = ConcertStatus.Published;
    }

    public void Cancel()
    {
        if (Status == ConcertStatus.Completed)
            throw new InvalidOperationException(
                "Completed concert cannot be cancelled.");

        if (Status == ConcertStatus.Cancelled)
            return;

        Status = ConcertStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != ConcertStatus.Published)
            throw new InvalidOperationException(
                "Only published concert can be completed.");

        Status = ConcertStatus.Completed;
    }

    public void UpdateInformation(
        string name,
        string description,
        string venue,
        DateTime startTime,
        DateTime endTime)
    {
        if (Status != ConcertStatus.Draft)
            throw new InvalidOperationException(
                "Only draft concert can be updated.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Concert name is required.");

        if (string.IsNullOrWhiteSpace(venue))
            throw new ArgumentException("Venue is required.");

        if (endTime <= startTime)
            throw new ArgumentException(
                "End time must be after start time.");

        Name = name.Trim();
        Description = description.Trim();
        Venue = venue.Trim();
        StartTime = startTime;
        EndTime = endTime;
    }

    public void AddTicketCategory(TicketCategory category)
    {
        if (Status != ConcertStatus.Draft)
            throw new InvalidOperationException(
                "Cannot modify published concert.");

        if (_ticketCategories.Any(x => x.Name == category.Name))
            throw new InvalidOperationException(
                $"Ticket category '{category.Name}' already exists.");

        _ticketCategories.Add(category);
    }
}