﻿using MediatR;

namespace Product.Api.Applications.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
